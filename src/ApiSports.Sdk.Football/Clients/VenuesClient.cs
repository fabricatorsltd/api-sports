using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class VenuesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Venue[]>> GetAsync(
        VenuesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/venues",
            query,
            VenuesJsonContext.Default.ApiResponseVenueArray,
            cancellationToken);
    }
}
