using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Basketball.Json;
using ApiSports.Sdk.Basketball.Models;
using ApiSports.Sdk.Basketball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Basketball.Clients;

public sealed class LeaguesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<League[]>> GetAsync(
        LeaguesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/leagues",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseLeagueArray,
            cancellationToken);
    }
}
