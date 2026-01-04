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

        RateLimitScope scope = RateLimitScope.FromBaseUri(options.BaseUri);
        ApiSportsRequestContext requestContext = ApiSportsRequestContext.FromBaseUri(options.BaseUri, options.Sport);

        ApiKeyHandler statusApiKeyHandler = new ApiKeyHandler(options.ApiKey)
        {
            InnerHandler = statusBaseHandler
        };

        HttpClient statusHttp = new HttpClient(statusApiKeyHandler)
        {
            BaseAddress = options.BaseUri,
            Timeout = options.Timeout
        };

        ApiSportsStatusClient statusClient = new ApiSportsStatusClient(new ApiSportsHttpClient(statusHttp, logger));
        ApiSportsPacingRateLimiter rateLimiter = new ApiSportsPacingRateLimiter(options.RateLimit, statusClient, logger);

        ApiKeyHandler apiKeyHandler = new ApiKeyHandler(options.ApiKey)
        {
            InnerHandler = baseHandler
        };

        RateLimitTrackingHandler trackingHandler = new RateLimitTrackingHandler(finalStore, scope)
        {
            InnerHandler = apiKeyHandler
        };

        RateLimitEnforcementHandler enforcementHandler = new RateLimitEnforcementHandler(finalStore, options.RateLimit, scope, rateLimiter, requestContext)
        {
            InnerHandler = trackingHandler
        };

        HttpClient http = new HttpClient(enforcementHandler)
        {
            BaseAddress = options.BaseUri,
            Timeout = options.Timeout
        };

        ApiSportsHttpClient client = new ApiSportsHttpClient(http, logger, rateLimiter, requestContext);
        return client;
    }
}
