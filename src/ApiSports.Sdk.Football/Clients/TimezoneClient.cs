using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Clients;

public sealed class TimezoneClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<TimezoneResponse[]>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/timezone",
            null,
            TimezoneJsonContext.Default.ApiResponseTimezoneResponseArray,
            cancellationToken);
    }
}
