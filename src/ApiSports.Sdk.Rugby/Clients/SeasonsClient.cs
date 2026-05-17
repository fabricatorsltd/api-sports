using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Rugby.Json;

namespace ApiSports.Sdk.Rugby.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            RugbyJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
