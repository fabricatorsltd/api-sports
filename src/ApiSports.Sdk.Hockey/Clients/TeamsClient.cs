using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Hockey.Json;
using ApiSports.Sdk.Hockey.Models;
using ApiSports.Sdk.Hockey.QueryParams;

namespace ApiSports.Sdk.Hockey.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }

    public Task<ApiResponse<TeamStatisticsResponse>> GetStatisticsAsync(
        TeamsStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/statistics",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseTeamStatisticsResponse,
            cancellationToken);
    }
}
