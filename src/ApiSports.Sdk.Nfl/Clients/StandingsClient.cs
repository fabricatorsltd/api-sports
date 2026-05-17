using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Json;
using ApiSports.Sdk.Nfl.Models;
using ApiSports.Sdk.Nfl.QueryParams;

namespace ApiSports.Sdk.Nfl.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            NflJsonSerializerContext.Default.ApiResponseStandingArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetConferencesAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/conferences",
            query,
            NflJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }

    public Task<ApiResponse<string[]>> GetDivisionsAsync(
        StandingsLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings/divisions",
            query,
            NflJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
