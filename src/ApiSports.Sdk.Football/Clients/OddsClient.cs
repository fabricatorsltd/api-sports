using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class OddsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<OddsResponse[]>> GetAsync(
        OddsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds",
            query,
            OddsJsonContext.Default.ApiResponseOddsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<OddsResponse[]>> GetLiveAsync(
        OddsLiveQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/live",
            query,
            OddsJsonContext.Default.ApiResponseOddsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<OddsBetResponse[]>> GetLiveBetsAsync(
        OddsBetsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/live/bets",
            query,
            OddsJsonContext.Default.ApiResponseOddsBetResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<OddsMappingResponse[]>> GetMappingAsync(
        OddsMappingQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/mapping",
            query,
            OddsJsonContext.Default.ApiResponseOddsMappingResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<OddsBookmakerResponse[]>> GetBookmakersAsync(
        OddsBookmakersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bookmakers",
            query,
            OddsJsonContext.Default.ApiResponseOddsBookmakerResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<OddsBetResponse[]>> GetBetsAsync(
        OddsBetsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bets",
            query,
            OddsJsonContext.Default.ApiResponseOddsBetResponseArray,
            cancellationToken);
    }
}
