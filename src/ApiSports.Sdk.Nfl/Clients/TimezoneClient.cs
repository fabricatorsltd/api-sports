using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Json;

namespace ApiSports.Sdk.Nfl.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            NflJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
