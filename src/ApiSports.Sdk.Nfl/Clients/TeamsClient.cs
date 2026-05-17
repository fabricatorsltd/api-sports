using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Json;
using ApiSports.Sdk.Nfl.Models;
using ApiSports.Sdk.Nfl.QueryParams;

namespace ApiSports.Sdk.Nfl.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            NflJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }
}
