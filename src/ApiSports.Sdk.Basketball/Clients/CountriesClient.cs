using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Basketball.Json;
using ApiSports.Sdk.Basketball.Models;
using ApiSports.Sdk.Basketball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Basketball.Clients;

public sealed class CountriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Country[]>> GetAsync(
        CountriesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/countries",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseCountryArray,
            cancellationToken);
    }
}
