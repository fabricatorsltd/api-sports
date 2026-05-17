using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nba.Json;
using ApiSports.Sdk.Nba.Models;
using ApiSports.Sdk.Nba.QueryParams;

namespace ApiSports.Sdk.Nba.Clients;

public sealed class PlayersClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Player[]>> GetAsync(
        PlayersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players",
            query,
            NbaJsonSerializerContext.Default.ApiResponsePlayerArray,
            cancellationToken);
    }

    public Task<ApiResponse<PlayerGameStatistics[]>> GetStatisticsAsync(
        PlayersStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/statistics",
            query,
            NbaJsonSerializerContext.Default.ApiResponsePlayerGameStatisticsArray,
            cancellationToken);
    }
}
