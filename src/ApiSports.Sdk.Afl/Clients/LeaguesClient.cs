using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Afl.Models;
using ApiSports.Sdk.Afl.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class LeaguesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<League[]>> GetAsync(
        LeaguesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/leagues",
            query,
            AflJsonSerializerContext.Default.ApiResponseLeagueArray,
            cancellationToken);
    }
}
