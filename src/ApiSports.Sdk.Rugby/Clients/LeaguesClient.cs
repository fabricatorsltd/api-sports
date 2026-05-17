using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Rugby.Json;
using ApiSports.Sdk.Rugby.Models;
using ApiSports.Sdk.Rugby.QueryParams;

namespace ApiSports.Sdk.Rugby.Clients;

public sealed class LeaguesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<League[]>> GetAsync(
        LeaguesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/leagues",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseLeagueArray,
            cancellationToken);
    }
}
