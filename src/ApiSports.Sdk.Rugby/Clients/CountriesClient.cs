using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Rugby.Json;
using ApiSports.Sdk.Rugby.Models;
using ApiSports.Sdk.Rugby.QueryParams;

namespace ApiSports.Sdk.Rugby.Clients;

public sealed class CountriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Country[]>> GetAsync(
        CountriesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/countries",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseCountryArray,
            cancellationToken);
    }
}
