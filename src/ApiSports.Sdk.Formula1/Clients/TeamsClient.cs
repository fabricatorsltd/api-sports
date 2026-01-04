using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.QueryParams;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiTeamResponse[]>> GetAsync(
        TeamsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiTeamResponseArray,
            cancellationToken);
    }
}
