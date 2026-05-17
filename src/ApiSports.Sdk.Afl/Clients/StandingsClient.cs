using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Afl.Models;
using ApiSports.Sdk.Afl.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class StandingsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Standing[]>> GetAsync(
        StandingsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/standings",
            query,
            AflJsonSerializerContext.Default.ApiResponseStandingArray,
            cancellationToken);
    }
}
