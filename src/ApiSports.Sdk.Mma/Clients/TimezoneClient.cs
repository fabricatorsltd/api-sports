using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            MmaJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
