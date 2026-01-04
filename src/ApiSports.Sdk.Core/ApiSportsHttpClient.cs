using System.Net;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class ApiSportsHttpClient(
    HttpClient http,
    IApiSportsLogger? logger = null,
    IApiSportsRateLimiter? rateLimiter = null,
    ApiSportsRequestContext? context = null)
{
    private readonly IApiSportsLogger _logger = logger ?? NullApiSportsLogger.Instance;

    public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(
        string relativePath,
        IQueryString? query,
        JsonTypeInfo<ApiResponse<TResponse>> responseTypeInfo,
        CancellationToken ct)
    {
        ApiSportsRequestContext? requestContext = context;
        if (rateLimiter is not null)
        {
            requestContext = context
                ?? throw new InvalidOperationException("Request context must be provided when rate limiting is enabled.");

            await rateLimiter.WaitAsync(requestContext, ct).ConfigureAwait(false);
        }

        bool debugEnabled = _logger.IsEnabled(ApiSportsLogLevel.Debug);
        bool infoEnabled = _logger.IsEnabled(ApiSportsLogLevel.Information);
        bool warningEnabled = _logger.IsEnabled(ApiSportsLogLevel.Warning);
        bool errorEnabled = _logger.IsEnabled(ApiSportsLogLevel.Error);

        IReadOnlyDictionary<string, string?>? parameters =
            query?.ToQueryParameters();
        Uri uri = BuildUri(relativePath, parameters);
        using var req = new HttpRequestMessage(HttpMethod.Get, uri);

        if (debugEnabled)
        {
            string queryNames = parameters is null || parameters.Count == 0
                ? "none"
                : string.Join(", ", parameters.Keys);

            _logger.Log(
                ApiSportsLogLevel.Debug,
                $"Request {req.Method} {uri.AbsolutePath} (query: {queryNames}).");
        }

        Stopwatch? stopwatch = infoEnabled ? Stopwatch.StartNew() : null;
        HttpResponseMessage res = await http.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false);

        if (rateLimiter is not null && requestContext is not null)
        {
            TimeSpan? retryAfter = TryGetRetryAfter(res);
            rateLimiter.Report(requestContext, res.StatusCode, retryAfter);
        }

        string endpoint = uri.ToString();

        if (!res.IsSuccessStatusCode)
        {
            if (errorEnabled)
            {
                _logger.Log(
                    ApiSportsLogLevel.Error,
                    $"HTTP failure {(int)res.StatusCode} for {req.Method} {uri.AbsolutePath}.");
            }

            JsonElement? errors = await TryReadErrorsAsync(res, ct).ConfigureAwait(false);
            throw new ApiSportsApiException($"API request failed ({(int)res.StatusCode}).", res.StatusCode, endpoint, errors);
        }

        if (res.StatusCode == HttpStatusCode.NoContent)
        {
            if (debugEnabled)
            {
                _logger.Log(
                    ApiSportsLogLevel.Debug,
                    $"Received 204 No Content for {req.Method} {uri.AbsolutePath}.");
            }

            if (warningEnabled)
            {
                _logger.Log(
                    ApiSportsLogLevel.Warning,
                    $"No content response for {req.Method} {uri.AbsolutePath}; returning empty response.");
            }

            if (infoEnabled && stopwatch is not null)
            {
                stopwatch.Stop();
                _logger.Log(
                    ApiSportsLogLevel.Information,
                    $"{req.Method} {uri.AbsolutePath} -> {(int)res.StatusCode} in {stopwatch.ElapsedMilliseconds}ms.");
            }

            return new ApiResponse<TResponse> { Results = 0 };
        }

        await using Stream stream = await res.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);

        if (debugEnabled)
        {
            _logger.Log(
                ApiSportsLogLevel.Debug,
                $"Deserializing response to {typeof(TResponse).Name}.");
        }

        ApiResponse<TResponse>? parsed;
        try
        {
            parsed = await JsonSerializer.DeserializeAsync(
                stream,
                responseTypeInfo,
                ct).ConfigureAwait(false);
        }
        catch (JsonException ex)
        {
            if (errorEnabled)
            {
                _logger.Log(
                    ApiSportsLogLevel.Error,
                    $"Failed to deserialize response for {req.Method} {uri.AbsolutePath}.",
                    ex);
            }

            throw;
        }
        catch (InvalidOperationException ex)
        {
            if (errorEnabled)
            {
                _logger.Log(
                    ApiSportsLogLevel.Error,
                    $"Missing JsonTypeInfo for {typeof(TResponse).Name}. Ensure the response type is registered in a JsonSerializerContext.",
                    ex);
            }

            throw;
        }

        if (parsed is null)
        {
            throw new ApiSportsApiException("Empty or invalid JSON response.", HttpStatusCode.InternalServerError, endpoint, null);
        }

        if (HasErrors(parsed.Errors))
        {
            if (warningEnabled)
            {
                _logger.Log(
                    ApiSportsLogLevel.Warning,
                    $"API returned errors for {req.Method} {uri.AbsolutePath} with 200 status.");
            }

            throw new ApiSportsApiException("API returned errors.", HttpStatusCode.BadRequest, endpoint, parsed.Errors);
        }

        if (infoEnabled && stopwatch is not null)
        {
            stopwatch.Stop();
            _logger.Log(
                ApiSportsLogLevel.Information,
                $"{req.Method} {uri.AbsolutePath} -> {(int)res.StatusCode} in {stopwatch.ElapsedMilliseconds}ms.");

            if (parsed.Paging is not null)
            {
                _logger.Log(
                    ApiSportsLogLevel.Information,
                    $"Paging {parsed.Paging.Current} / {parsed.Paging.Total} for {req.Method} {uri.AbsolutePath}.");
            }
        }

        return parsed;
    }
    
    private static bool HasErrors(JsonElement? errors)
    {
        if (!errors.HasValue)
        {
            return false;
        }

        JsonElement e = errors.Value;

        if (e.ValueKind == JsonValueKind.Array)
        {
            return e.GetArrayLength() > 0;
        }

        if (e.ValueKind == JsonValueKind.Object)
        {
            return e.EnumerateObject().Any();
        }

        if (e.ValueKind == JsonValueKind.String)
        {
            string? s = e.GetString();
            return !string.IsNullOrWhiteSpace(s);
        }

        return false;
    }

    private static async Task<JsonElement?> TryReadErrorsAsync(HttpResponseMessage res, CancellationToken ct)
    {
        try
        {
            await using Stream stream = await res.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
            JsonDocument doc = await JsonDocument.ParseAsync(stream, cancellationToken: ct).ConfigureAwait(false);

            if (doc.RootElement.TryGetProperty("errors", out JsonElement errors))
            {
                return errors.Clone();
            }

            return doc.RootElement.Clone();
        }
        catch
        {
            return null;
        }
    }

    private static TimeSpan? TryGetRetryAfter(HttpResponseMessage response)
    {
        if (response.Headers.TryGetValues(ApiSportsHeaderNames.RetryAfter, out IEnumerable<string>? values))
        {
            string? first = values.FirstOrDefault();
            if (first is not null && int.TryParse(first, out int seconds) && seconds > 0)
            {
                return TimeSpan.FromSeconds(seconds);
            }
        }

        return null;
    }

    private Uri BuildUri(string relativePath, IReadOnlyDictionary<string, string?>? query)
    {
        Uri baseUri = http.BaseAddress ?? throw new InvalidOperationException("HttpClient.BaseAddress must be set.");
        var builder = new UriBuilder(new Uri(baseUri, relativePath));

        if (query is null || query.Count == 0)
        {
            return builder.Uri;
        }

        var sb = new StringBuilder();
        foreach (KeyValuePair<string, string?> kv in query)
        {
            if (kv.Value is null)
            {
                continue;
            }

            if (sb.Length > 0)
            {
                sb.Append('&');
            }

            sb.Append(Uri.EscapeDataString(kv.Key));
            sb.Append('=');
            sb.Append(Uri.EscapeDataString(kv.Value));
        }

        builder.Query = sb.ToString();
        return builder.Uri;
    }
}
