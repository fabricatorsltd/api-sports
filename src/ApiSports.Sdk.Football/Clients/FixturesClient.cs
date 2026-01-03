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
    
    public Task<ApiResponse<FixtureResponse[]>> GetRoundsAsync(
        FixturesRoundsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/rounds",
            query,
            //FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureResponse[]>> GetHeadToHeadAsync(
        FixturesHeadToHeadQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/headtohead",
            query,
            //FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureResponse[]>> GetStatisticsAsync(
        FixturesStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/statistics",
            query,
            //FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureResponse[]>> GetEventsAsync(
        FixturesEventsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/events",
            query,
            //FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureResponse[]>> GetLineupsAsync(
        FixturesLineupsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/lineups",
            query,
            //FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<FixtureResponse[]>> GetPlayersAsync(
        FixturesPlayersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures/players",
            query,
            //FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
}

