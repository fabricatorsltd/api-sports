using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class SidelinedClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<SidelinedResponse[]>> GetAsync(
        SidelinedQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/sidelined",
            query,
            SidelinedJsonContext.Default.ApiResponseSidelinedResponseArray,
            cancellationToken);
    }
}
