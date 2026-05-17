using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nba.Json;

namespace ApiSports.Sdk.Nba.Clients;

public sealed class LeaguesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/leagues",
            null,
            NbaJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
