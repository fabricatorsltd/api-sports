using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Rugby.Json;
using ApiSports.Sdk.Rugby.Models;
using ApiSports.Sdk.Rugby.QueryParams;

namespace ApiSports.Sdk.Rugby.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[][]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseStandingArrayArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetStagesAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/stages",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetGroupsAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/groups",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
