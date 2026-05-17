using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Handball.Json;

namespace ApiSports.Sdk.Handball.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<string[]>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            HandballJsonSerializerContext.Default.ApiResponseStringArray,
            cancellationToken);
    }
}
