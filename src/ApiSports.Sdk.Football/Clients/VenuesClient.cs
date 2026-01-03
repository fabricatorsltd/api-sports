using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Clients;

public sealed class VenuesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Venue[]>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/venues",
            null,
            VenuesJsonContext.Default.ApiResponseVenueArray,
            cancellationToken);
    }
}
