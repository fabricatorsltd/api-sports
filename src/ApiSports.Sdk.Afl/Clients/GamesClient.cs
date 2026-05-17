using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Afl.Models;
using ApiSports.Sdk.Afl.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            AflJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameEventsResponse[]>> GetEventsAsync(
        GameLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/events",
            query,
            AflJsonSerializerContext.Default.ApiResponseGameEventsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameQuartersResponse[]>> GetQuartersAsync(
        GameLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/quarters",
            query,
            AflJsonSerializerContext.Default.ApiResponseGameQuartersResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameTeamStatisticsResponse[]>> GetTeamStatisticsAsync(
        GameLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/statistics/teams",
            query,
            AflJsonSerializerContext.Default.ApiResponseGameTeamStatisticsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<GamePlayerStatisticsResponse[]>> GetPlayerStatisticsAsync(
        GameLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/statistics/players",
            query,
            AflJsonSerializerContext.Default.ApiResponseGamePlayerStatisticsResponseArray,
            cancellationToken);
    }
}
