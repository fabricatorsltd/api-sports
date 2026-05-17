using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Json;
using ApiSports.Sdk.Nfl.Models;
using ApiSports.Sdk.Nfl.QueryParams;

namespace ApiSports.Sdk.Nfl.Clients;

public sealed class PlayersClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Player[]>> GetAsync(
        PlayersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players",
            query,
            NflJsonSerializerContext.Default.ApiResponsePlayerArray,
            cancellationToken);
    }

    public Task<ApiResponse<PlayerSeasonStatistics[]>> GetStatisticsAsync(
        PlayersStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/statistics",
            query,
            NflJsonSerializerContext.Default.ApiResponsePlayerSeasonStatisticsArray,
            cancellationToken);
    }
}
