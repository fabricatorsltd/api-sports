using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Handball.Json;

namespace ApiSports.Sdk.Handball.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            HandballJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
