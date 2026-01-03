using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class PredictionsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiPredictionsResponse[]>> GetAsync(
        PredictionsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/predictions",
            query,
            PredictionsJsonContext.Default.ApiResponseApiPredictionsResponseArray,
            cancellationToken);
    }
}
