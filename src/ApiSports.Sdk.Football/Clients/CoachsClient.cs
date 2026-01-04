using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class CoachsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Coach[]>> GetAsync(
        CoachsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/coachs",
            query,
            CoachsJsonContext.Default.ApiResponseCoachArray,
            cancellationToken);
    }
}
