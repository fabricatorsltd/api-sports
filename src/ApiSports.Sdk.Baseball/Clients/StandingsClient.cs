using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Baseball.Json;
using ApiSports.Sdk.Baseball.Models;
using ApiSports.Sdk.Baseball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Baseball.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[][]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseStandingArrayArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetStagesAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/stages",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetGroupsAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/groups",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
