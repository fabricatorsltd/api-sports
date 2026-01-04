using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiTeamResponse[]>> GetAsync(
        TeamsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            TeamsJsonContext.Default.ApiResponseApiTeamResponseArray,
            cancellationToken);
    }
    
    public Task<ApiResponse<TeamStatisticsResponse>> GetStatisticsAsync(
        TeamsStatisticsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/statistics",
            query,
            TeamsJsonContext.Default.ApiResponseTeamStatisticsResponse,
            cancellationToken);
    }
    
    public Task<ApiResponse<int[]>> GetSeasonsAsync(
        TeamsSeasonsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/seasons",
            query,
            TeamsJsonContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }

    public Task<ApiResponse<Country[]>> GetCountriesAsync(
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams/countries",
            null,
            TeamsJsonContext.Default.ApiResponseCountryArray,
            cancellationToken);
    }
}
