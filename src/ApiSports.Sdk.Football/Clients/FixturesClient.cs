using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class FixturesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<FixtureResponse[]>> GetAsync(
        FixturesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/fixtures",
            query,
            FixturesJsonContext.Default.ApiResponseFixtureResponseArray,
            cancellationToken);
    }
}

