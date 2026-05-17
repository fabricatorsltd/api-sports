using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;
using ApiSports.Sdk.Mma.Models;
using ApiSports.Sdk.Mma.QueryParams;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class TeamsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Team[]>> GetAsync(
        TeamsQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/teams",
            query,
            MmaJsonSerializerContext.Default.ApiResponseTeamArray,
            cancellationToken);
    }
}
