using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            AflJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
