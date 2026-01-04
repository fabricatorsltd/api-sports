using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;

namespace ApiSports.Sdk.Football.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            TimezoneJsonContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
