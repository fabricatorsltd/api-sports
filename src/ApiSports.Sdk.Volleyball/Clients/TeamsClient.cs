using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;
using ApiSports.Sdk.Volleyball.Models;
using ApiSports.Sdk.Volleyball.QueryParams;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }

    public Task<ApiResponse<TeamStatisticsResponse>> GetStatisticsAsync(
        TeamsStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/statistics",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseTeamStatisticsResponse,
            cancellationToken);
    }
}
