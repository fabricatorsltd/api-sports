using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Formula1.Json;
using ApiSports.Sdk.Formula1.Models;
using ApiSports.Sdk.Formula1.QueryParams;

namespace ApiSports.Sdk.Formula1.Clients;

public sealed class DriversClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiDriverResponse[]>> GetAsync(
        DriversQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/drivers",
            query,
            Formula1JsonSerializerContext.Default.ApiResponseApiDriverResponseArray,
            cancellationToken);
    }
}
