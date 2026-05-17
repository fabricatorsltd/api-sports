using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class StatusClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<StatusResponse>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/status",
            null,
            VolleyballJsonSerializerContext.Default.ApiResponseStatusResponse,
            cancellationToken);
    }
}
