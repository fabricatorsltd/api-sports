using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Handball.Json;
using ApiSports.Sdk.Handball.Models;
using ApiSports.Sdk.Handball.QueryParams;

namespace ApiSports.Sdk.Handball.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            HandballJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }

    public Task<ApiResponse<TeamStatisticsResponse>> GetStatisticsAsync(
        TeamsStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/statistics",
            query,
            HandballJsonSerializerContext.Default.ApiResponseTeamStatisticsResponse,
            cancellationToken);
    }
}
