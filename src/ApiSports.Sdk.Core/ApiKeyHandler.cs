using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class ApiKeyHandler(string apiKey) : DelegatingHandler
{
    private readonly string _apiKey = string.IsNullOrWhiteSpace(apiKey)
        ? throw new ArgumentException("API key is required.", nameof(apiKey))
        : apiKey;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!request.Headers.Contains(ApiSportsHeaderNames.ApiKey))
        {
            request.Headers.TryAddWithoutValidation(ApiSportsHeaderNames.ApiKey, _apiKey);
        }

        return base.SendAsync(request, cancellationToken);
    }
}
