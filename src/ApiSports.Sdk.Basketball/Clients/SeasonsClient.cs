using System.Text.Json;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Basketball.Json;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Basketball.Clients;

public sealed class SeasonsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<JsonElement[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/seasons",
            null,
            BasketballJsonSerializerContext.Default.ApiResponseJsonElementArray,
            cancellationToken);
    }
}
