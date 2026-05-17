using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            AflJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
