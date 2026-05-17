using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Baseball.Json;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Baseball.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            BaseballJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
