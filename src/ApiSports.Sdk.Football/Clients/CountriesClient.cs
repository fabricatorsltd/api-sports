using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Clients;

public sealed class CountriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Country[]>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/countries",
            null,
            CountriesJsonContext.Default.ApiResponseCountryArray,
            cancellationToken);
    }
}
