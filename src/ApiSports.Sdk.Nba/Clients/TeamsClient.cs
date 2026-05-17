using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nba.Json;
using ApiSports.Sdk.Nba.Models;
using ApiSports.Sdk.Nba.QueryParams;

namespace ApiSports.Sdk.Nba.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            NbaJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }

    public Task<ApiResponse<TeamSeasonStatistics[]>> GetStatisticsAsync(
        TeamsStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/statistics",
            query,
            NbaJsonSerializerContext.Default.ApiResponseTeamSeasonStatisticsArray,
            cancellationToken);
    }
}
