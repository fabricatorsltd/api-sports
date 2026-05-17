using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Hockey.Json;

namespace ApiSports.Sdk.Hockey.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            HockeyJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
