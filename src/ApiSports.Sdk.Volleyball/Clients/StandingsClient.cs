using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;
using ApiSports.Sdk.Volleyball.Models;
using ApiSports.Sdk.Volleyball.QueryParams;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[][]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseStandingArrayArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetStagesAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/stages",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetGroupsAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/groups",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
