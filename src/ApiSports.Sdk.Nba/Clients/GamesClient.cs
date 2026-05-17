using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nba.Json;
using ApiSports.Sdk.Nba.Models;
using ApiSports.Sdk.Nba.QueryParams;

namespace ApiSports.Sdk.Nba.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            NbaJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameTeamStatistics[]>> GetStatisticsAsync(
        GamesStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/statistics",
            query,
            NbaJsonSerializerContext.Default.ApiResponseGameTeamStatisticsArray,
            cancellationToken);
    }
}
