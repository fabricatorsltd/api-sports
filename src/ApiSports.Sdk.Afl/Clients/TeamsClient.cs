using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Afl.Models;
using ApiSports.Sdk.Afl.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            AflJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }

    public Task<ApiResponse<TeamStatisticsResponse[]>> GetStatisticsAsync(
        TeamsStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/statistics",
            query,
            AflJsonSerializerContext.Default.ApiResponseTeamStatisticsResponseArray,
            cancellationToken);
    }
}
