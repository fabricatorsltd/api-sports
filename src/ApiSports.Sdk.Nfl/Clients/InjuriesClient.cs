using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Nfl.Json;
using ApiSports.Sdk.Nfl.Models;
using ApiSports.Sdk.Nfl.QueryParams;

namespace ApiSports.Sdk.Nfl.Clients;

public sealed class InjuriesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Injury[]>> GetAsync(
        InjuriesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/injuries",
            query,
            NflJsonSerializerContext.Default.ApiResponseInjuryArray,
            cancellationToken);
    }
}
