using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class FixturesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<FixtureResponse[]>> GetAsync(
        FixturesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures",
            query,
            FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<string[]>> GetRoundsAsync(
        FixturesRoundsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/rounds",
            query,
            FixturesJsonContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<HeadToHead[]>> GetHeadToHeadAsync(
        FixturesHeadToHeadQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/headtohead",
            query,
            FixturesJsonContext.Default.ApiResponseHeadToHeadArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureStatisticsResponse[]>> GetStatisticsAsync(
        FixturesStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/statistics",
            query,
            FixturesJsonContext.Default.ApiResponseFixtureStatisticsResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureEvent[]>> GetEventsAsync(
        FixturesEventsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/events",
            query,
            FixturesJsonContext.Default.ApiResponseFixtureEventArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureLineupResponse[]>> GetLineupsAsync(
        FixturesLineupsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/lineups",
            query,
            FixturesJsonContext.Default.ApiResponseFixtureLineupResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixturePlayerResponse[]>> GetPlayersAsync(
        FixturesPlayersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/players",
            query,
            FixturesJsonContext.Default.ApiResponseFixturePlayerResponseArray,
            cancellationToken);
    }
}
