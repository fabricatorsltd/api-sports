using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class StatusClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<StatusResponse>> GetAsync(CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/status",
            null,
            AflJsonSerializerContext.Default.ApiResponseStatusResponse,
            cancellationToken);
    }
}
