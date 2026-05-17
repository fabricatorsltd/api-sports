using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Baseball.Json;
using ApiSports.Sdk.Baseball.Models;
using ApiSports.Sdk.Baseball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Baseball.Clients;

public sealed class LeaguesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<League[]>> GetAsync(
        LeaguesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/leagues",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseLeagueArray,
            cancellationToken);
    }
}
