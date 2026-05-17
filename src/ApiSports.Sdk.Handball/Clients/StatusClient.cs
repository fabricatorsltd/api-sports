using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Handball.Json;

namespace ApiSports.Sdk.Handball.Clients;

public sealed class StatusClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<StatusResponse>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/status",
            null,
            HandballJsonSerializerContext.Default.ApiResponseStatusResponse,
            cancellationToken);
    }
}
