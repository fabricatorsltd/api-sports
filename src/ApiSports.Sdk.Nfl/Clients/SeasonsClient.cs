using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Json;

namespace ApiSports.Sdk.Nfl.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            NflJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
