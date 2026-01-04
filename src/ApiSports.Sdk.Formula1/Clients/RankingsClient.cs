using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.QueryParams;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class RankingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiTeamRankingResponse[]>> GetTeamsAsync(
        RankingsTeamsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/rankings/teams",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiTeamRankingResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiDriverRankingResponse[]>> GetDriversAsync(
        RankingsDriversQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/rankings/drivers",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiDriverRankingResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiRaceRankingResponse[]>> GetRacesAsync(
        RankingsRacesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/rankings/races",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiRaceRankingResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiFastestLapRankingResponse[]>> GetFastestLapsAsync(
        RankingsFastestLapsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/rankings/fastestlaps",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiFastestLapRankingResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiStartingGridRankingResponse[]>> GetStartingGridAsync(
        RankingsStartingGridQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/rankings/startinggrid",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiStartingGridRankingResponseArray,
            cancellationToken);
    }
}
