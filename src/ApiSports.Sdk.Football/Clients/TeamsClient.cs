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
}
