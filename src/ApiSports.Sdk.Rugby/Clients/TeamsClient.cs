using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Rugby.Json;
using ApiSports.Sdk.Rugby.Models;
using ApiSports.Sdk.Rugby.QueryParams;

namespace ApiSports.Sdk.Rugby.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }

    public Task<ApiResponse<TeamStatisticsResponse>> GetStatisticsAsync(
        TeamsStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/statistics",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseTeamStatisticsResponse,
            cancellationToken);
    }
}
