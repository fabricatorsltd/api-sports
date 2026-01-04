using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            Formula1JsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
