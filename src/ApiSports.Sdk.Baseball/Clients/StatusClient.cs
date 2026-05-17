using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Baseball.Json;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Baseball.Clients;

public sealed class StatusClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<StatusResponse>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/status",
            null,
            BaseballJsonSerializerContext.Default.ApiResponseStatusResponse,
            cancellationToken);
    }
}
