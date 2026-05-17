using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Baseball.Json;
using ApiSports.Sdk.Baseball.Models;
using ApiSports.Sdk.Baseball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Baseball.Clients;

public sealed class CountriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Country[]>> GetAsync(
        CountriesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/countries",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseCountryArray,
            cancellationToken);
    }
}
