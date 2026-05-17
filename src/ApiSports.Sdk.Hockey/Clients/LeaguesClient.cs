using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Hockey.Json;
using ApiSports.Sdk.Hockey.Models;
using ApiSports.Sdk.Hockey.QueryParams;

namespace ApiSports.Sdk.Hockey.Clients;

public sealed class LeaguesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<League[]>> GetAsync(
        LeaguesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/leagues",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseLeagueArray,
            cancellationToken);
    }
}
