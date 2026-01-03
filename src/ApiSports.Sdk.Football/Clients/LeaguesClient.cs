using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public class LeaguesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiLeagueResponse[]>> GetAsync(
        LeaguesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/leagues",
            query,
            LeaguesJsonContext.Default.ApiResponseApiLeagueResponseArray,
            cancellationToken);
    }
}
