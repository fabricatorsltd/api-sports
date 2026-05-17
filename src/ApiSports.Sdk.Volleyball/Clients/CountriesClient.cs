using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;
using ApiSports.Sdk.Volleyball.Models;
using ApiSports.Sdk.Volleyball.QueryParams;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class CountriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Country[]>> GetAsync(
        CountriesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/countries",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseCountryArray,
            cancellationToken);
    }
}
