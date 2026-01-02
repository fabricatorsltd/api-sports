using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class ApiSportsHttpClient(HttpClient http)
{
    public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(
        string relativePath,
        IQueryString? query,
        JsonTypeInfo<ApiResponse<TResponse>> responseTypeInfo,
        CancellationToken ct)
    {
        IReadOnlyDictionary<string, string?>? parameters =
            query?.ToQueryParameters();
        Uri uri = BuildUri(relativePath, parameters);
        using var req = new HttpRequestMessage(HttpMethod.Get, uri);

        HttpResponseMessage res = await http.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false);

        string endpoint = uri.ToString();

        if (!res.IsSuccessStatusCode)
        {
            JsonElement? errors = await TryReadErrorsAsync(res, ct).ConfigureAwait(false);
            throw new ApiSportsApiException($"API request failed ({(int)res.StatusCode}).", res.StatusCode, endpoint, errors);
        }

        await using Stream stream = await res.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);

        ApiResponse<TResponse>? parsed = await JsonSerializer.DeserializeAsync(
            stream,
            responseTypeInfo,
            ct).ConfigureAwait(false);

        if (parsed is null)
        {
            throw new ApiSportsApiException("Empty or invalid JSON response.", HttpStatusCode.InternalServerError, endpoint, null);
        }

        return HasErrors(parsed.Errors) ? throw new ApiSportsApiException("API returned errors.", HttpStatusCode.BadRequest, endpoint, parsed.Errors) : parsed;
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
