using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.QueryParams;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class PitStopsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiPitStopResponse[]>> GetAsync(
        PitStopsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/pitstops",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiPitStopResponseArray,
            cancellationToken);
    }
}
