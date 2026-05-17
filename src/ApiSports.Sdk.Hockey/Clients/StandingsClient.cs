using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Hockey.Json;
using ApiSports.Sdk.Hockey.Models;
using ApiSports.Sdk.Hockey.QueryParams;

namespace ApiSports.Sdk.Hockey.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[][]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseStandingArrayArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetStagesAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/stages",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetGroupsAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/groups",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
