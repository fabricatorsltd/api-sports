using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Handball.Json;
using ApiSports.Sdk.Handball.Models;
using ApiSports.Sdk.Handball.QueryParams;

namespace ApiSports.Sdk.Handball.Clients;

public sealed class CountriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Country[]>> GetAsync(
        CountriesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/countries",
            query,
            HandballJsonSerializerContext.Default.ApiResponseCountryArray,
            cancellationToken);
    }
}
