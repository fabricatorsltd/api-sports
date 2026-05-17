using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class StatusClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<StatusResponse>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/status",
            null,
            MmaJsonSerializerContext.Default.ApiResponseStatusResponse,
            cancellationToken);
    }
}
