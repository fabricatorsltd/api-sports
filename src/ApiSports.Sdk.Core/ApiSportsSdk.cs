using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class ApiSportsSdk(ApiSportsClientOptions options, IRateLimitStateStore store, ISportBaseUriResolver resolver)
{
    public static ApiSportsSdk Create(
        string apiKey,
        IRateLimitStateStore? store = null,
        ISportBaseUriResolver? resolver = null,
        Action<ApiSportsClientOptions>? configure = null)
    {
        var options = new ApiSportsClientOptions
        {
            ApiKey = apiKey
        };

        configure?.Invoke(options);

        IRateLimitStateStore finalStore = store ?? new InMemoryRateLimitStateStore();
        ISportBaseUriResolver finalResolver = resolver ?? new DefaultSportBaseUriResolver();

        return new ApiSportsSdk(options, finalStore, finalResolver);
    }

    public ApiSportsHttpClient ForSport(ApiSportsSport sport)
    {
        Uri baseUri = resolver.Resolve(sport);

        var sportOptions = new ApiSportsClientOptions
        {
            ApiKey = options.ApiKey,
            BaseUri = baseUri,
            Timeout = options.Timeout,
            RateLimit = options.RateLimit
        };

        return ApiSportsClientFactory.Create(sportOptions, store);
    }
}
