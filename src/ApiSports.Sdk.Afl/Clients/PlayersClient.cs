using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Afl.Models;
using ApiSports.Sdk.Afl.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class PlayersClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Player[]>> GetAsync(
        PlayersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players",
            query,
            AflJsonSerializerContext.Default.ApiResponsePlayerArray,
            cancellationToken);
    }

    public Task<ApiResponse<PlayerStatisticsResponse[]>> GetStatisticsAsync(
        PlayersStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/statistics",
            query,
            AflJsonSerializerContext.Default.ApiResponsePlayerStatisticsResponseArray,
            cancellationToken);
    }
}
