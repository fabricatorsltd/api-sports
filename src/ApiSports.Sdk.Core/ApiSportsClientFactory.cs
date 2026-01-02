using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public static class ApiSportsClientFactory
{
    public static ApiSportsHttpClient Create(
        ApiSportsClientOptions options,
        IRateLimitStateStore? store = null,
        HttpMessageHandler? innerHandler = null)
    {
        IRateLimitStateStore finalStore = store ?? new InMemoryRateLimitStateStore();
        HttpMessageHandler baseHandler = innerHandler ?? new SocketsHttpHandler();

        var scope = RateLimitScope.FromBaseUri(options.BaseUri);

        var apiKeyHandler = new ApiKeyHandler(options.ApiKey)
        {
            InnerHandler = baseHandler
        };

        var trackingHandler = new RateLimitTrackingHandler(finalStore, scope)
        {
            InnerHandler = apiKeyHandler
        };

        var enforcementHandler = new RateLimitEnforcementHandler(finalStore, options.RateLimit, scope)
        {
            InnerHandler = trackingHandler
        };

        var http = new HttpClient(enforcementHandler)
        {
            BaseAddress = options.BaseUri,
            Timeout = options.Timeout
        };

        var client = new ApiSportsHttpClient(http);
        return client;
    }
}
