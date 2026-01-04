using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Core.Json;

namespace ApiSports.Sdk.Core;

internal sealed class ApiSportsStatusClient(ApiSportsHttpClient http) : IApiSportsStatusClient
{
    public async Task<StatusResponse?> GetStatusAsync(CancellationToken ct)
    {
        ApiResponse<StatusResponse> response = await http.GetAsync(
            "/status",
            null,
            ApiSportsCommonJsonContext.Default.ApiResponseStatusResponse,
            ct).ConfigureAwait(false);

        return response.Response;
    }
}
