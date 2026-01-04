using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.QueryParams;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class RacesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiRaceResponse[]>> GetAsync(
        RacesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/races",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiRaceResponseArray,
            cancellationToken);
    }
}
