using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class TrophiesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<TrophyResponse[]>> GetAsync(
        TrophiesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/trophies",
            query,
            TrophiesJsonContext.Default.ApiResponseTrophyResponseArray,
            cancellationToken);
    }
}
