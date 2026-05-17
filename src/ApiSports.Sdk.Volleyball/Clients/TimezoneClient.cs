using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            VolleyballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
