using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class InjuriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Injury[]>> GetAsync(
        InjuriesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/injuries",
            query,
            InjuriesJsonContext.Default.ApiResponseInjuryArray,
            cancellationToken);
    }
}
