using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;
using ApiSports.Sdk.Mma.Models;
using ApiSports.Sdk.Mma.QueryParams;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class FightsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Fight[]>> GetAsync(
        FightsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fights",
            query,
            MmaJsonSerializerContext.Default.ApiResponseFightArray,
            cancellationToken);
    }

    public Task<ApiResponse<FightResult[]>> GetResultsAsync(
        FightLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fights/results",
            query,
            MmaJsonSerializerContext.Default.ApiResponseFightResultArray,
            cancellationToken);
    }

    public Task<ApiResponse<FightStatistics[]>> GetFighterStatisticsAsync(
        FightLookupQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fights/statistics/fighters",
            query,
            MmaJsonSerializerContext.Default.ApiResponseFightStatisticsArray,
            cancellationToken);
    }
}
