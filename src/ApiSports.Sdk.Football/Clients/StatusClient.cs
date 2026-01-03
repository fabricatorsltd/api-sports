using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Clients;

public sealed class StatusClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Status>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/status",
            null,
            StatusJsonContext.Default.ApiResponseStatus,
            cancellationToken);
    }
}
