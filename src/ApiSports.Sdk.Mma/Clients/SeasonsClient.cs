using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            MmaJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
