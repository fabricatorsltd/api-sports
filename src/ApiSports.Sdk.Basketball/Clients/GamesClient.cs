using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Basketball.Json;
using ApiSports.Sdk.Basketball.Models;
using ApiSports.Sdk.Basketball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Basketball.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameTeamStatistics[]>> GetTeamStatisticsAsync(
        GameLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/statistics/teams",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseGameTeamStatisticsArray,
            cancellationToken);
    }

    public Task<ApiResponse<GamePlayerStatistics[]>> GetPlayerStatisticsAsync(
        GameLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/statistics/players",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseGamePlayerStatisticsArray,
            cancellationToken);
    }
}
