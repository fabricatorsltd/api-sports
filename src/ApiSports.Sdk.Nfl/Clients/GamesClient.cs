using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Json;
using ApiSports.Sdk.Nfl.Models;
using ApiSports.Sdk.Nfl.QueryParams;

namespace ApiSports.Sdk.Nfl.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            NflJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameEvent[]>> GetEventsAsync(
        GameEventsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/events",
            query,
            NflJsonSerializerContext.Default.ApiResponseGameEventArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameTeamStatistics[]>> GetTeamStatisticsAsync(
        GameTeamStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/statistics/teams",
            query,
            NflJsonSerializerContext.Default.ApiResponseGameTeamStatisticsArray,
            cancellationToken);
    }

    public Task<ApiResponse<GamePlayerStatistics[]>> GetPlayerStatisticsAsync(
        GamePlayerStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/statistics/players",
            query,
            NflJsonSerializerContext.Default.ApiResponseGamePlayerStatisticsArray,
            cancellationToken);
    }
}
