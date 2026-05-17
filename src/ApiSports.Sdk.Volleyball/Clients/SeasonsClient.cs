using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            VolleyballJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
