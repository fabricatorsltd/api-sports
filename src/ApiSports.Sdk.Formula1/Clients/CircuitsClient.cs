using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.QueryParams;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class CircuitsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiCircuitResponse[]>> GetAsync(
        CircuitsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/circuits",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiCircuitResponseArray,
            cancellationToken);
    }
}
