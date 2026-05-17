using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nba.Json;

namespace ApiSports.Sdk.Nba.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            NbaJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
