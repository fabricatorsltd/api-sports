using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Handball.Json;
using ApiSports.Sdk.Handball.Models;
using ApiSports.Sdk.Handball.QueryParams;

namespace ApiSports.Sdk.Handball.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[][]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            HandballJsonSerializerContext.Default.ApiResponseStandingArrayArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetStagesAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/stages",
            query,
            HandballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetGroupsAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/groups",
            query,
            HandballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
