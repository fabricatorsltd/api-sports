using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class ApiSportsSdk(
    ApiSportsClientOptions options,
    IRateLimitStateStore store,
    ISportBaseUriResolver resolver,
    IApiSportsLogger? logger = null)
{
    private readonly IApiSportsLogger _logger = logger ?? NullApiSportsLogger.Instance;

    public static ApiSportsSdk Create(
        string apiKey,
        IRateLimitStateStore? store = null,
        ISportBaseUriResolver? resolver = null,
        Action<ApiSportsClientOptions>? configure = null,
        IApiSportsLogger? logger = null)
    {
        var options = new ApiSportsClientOptions
        {
            ApiKey = apiKey
        };

        configure?.Invoke(options);

        IRateLimitStateStore finalStore = store ?? new InMemoryRateLimitStateStore();
        ISportBaseUriResolver finalResolver = resolver ?? new DefaultSportBaseUriResolver();

        return new ApiSportsSdk(options, finalStore, finalResolver, logger);
    }

    public ApiSportsHttpClient ForSport(ApiSportsSport sport)
    {
        Uri baseUri = resolver.Resolve(sport);

        var sportOptions = new ApiSportsClientOptions
        {
            ApiKey = options.ApiKey,
            BaseUri = baseUri,
            Timeout = options.Timeout,
            RateLimit = options.RateLimit,
            Sport = sport
        };

        return ApiSportsClientFactory.Create(sportOptions, store, logger: _logger);
    }
}
