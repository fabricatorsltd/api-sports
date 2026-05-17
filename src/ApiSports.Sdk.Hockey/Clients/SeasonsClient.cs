using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Hockey.Json;

namespace ApiSports.Sdk.Hockey.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<int[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            HockeyJsonSerializerContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }
}
