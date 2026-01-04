using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public static class ApiSportsClientFactory
{
    public static ApiSportsHttpClient Create(
        ApiSportsClientOptions options,
        IRateLimitStateStore? store = null,
        HttpMessageHandler? innerHandler = null,
        IApiSportsLogger? logger = null)
    {
        IRateLimitStateStore finalStore = store ?? new InMemoryRateLimitStateStore();
        HttpMessageHandler baseHandler = innerHandler ?? new SocketsHttpHandler();
        HttpMessageHandler statusBaseHandler = innerHandler ?? new SocketsHttpHandler();

        var scope = RateLimitScope.FromBaseUri(options.BaseUri);
        var requestContext = ApiSportsRequestContext.FromBaseUri(options.BaseUri, options.Sport);

        var statusApiKeyHandler = new ApiKeyHandler(options.ApiKey)
        {
            InnerHandler = statusBaseHandler
        };

        var statusHttp = new HttpClient(statusApiKeyHandler)
        {
            BaseAddress = options.BaseUri,
            Timeout = options.Timeout
        };

        var statusClient = new ApiSportsStatusClient(new ApiSportsHttpClient(statusHttp, logger));
        var rateLimiter = new ApiSportsPacingRateLimiter(options.RateLimit, statusClient, logger);

        var apiKeyHandler = new ApiKeyHandler(options.ApiKey)
        {
            InnerHandler = baseHandler
        };

        var trackingHandler = new RateLimitTrackingHandler(finalStore, scope)
        {
            InnerHandler = apiKeyHandler
        };

        var enforcementHandler = new RateLimitEnforcementHandler(finalStore, options.RateLimit, scope, rateLimiter, requestContext)
        {
            InnerHandler = trackingHandler
        };

        var http = new HttpClient(enforcementHandler)
        {
            BaseAddress = options.BaseUri,
            Timeout = options.Timeout
        };

        var client = new ApiSportsHttpClient(http, logger, rateLimiter, requestContext);
        return client;
    }
}
