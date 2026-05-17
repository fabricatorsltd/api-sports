using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nba.Json;
using ApiSports.Sdk.Nba.Models;
using ApiSports.Sdk.Nba.QueryParams;

namespace ApiSports.Sdk.Nba.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            NbaJsonSerializerContext.Default.ApiResponseStandingArray,
            cancellationToken);
    }
}
