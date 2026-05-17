using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Basketball.Json;
using ApiSports.Sdk.Basketball.Models;
using ApiSports.Sdk.Basketball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Basketball.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[][]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseStandingArrayArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetStagesAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/stages",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetGroupsAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/groups",
            query,
            BasketballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
