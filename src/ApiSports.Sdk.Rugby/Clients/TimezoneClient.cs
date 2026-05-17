using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Rugby.Json;

namespace ApiSports.Sdk.Rugby.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            RugbyJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
