using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;
using ApiSports.Sdk.Volleyball.Models;
using ApiSports.Sdk.Volleyball.QueryParams;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class OddsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<OddsResponse[]>> GetAsync(
        OddsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseOddsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<BetDefinition[]>> GetBetsAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bets",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseBetDefinitionArray,
            cancellationToken);
    }

    public Task<ApiResponse<BookmakerDefinition[]>> GetBookmakersAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bookmakers",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseBookmakerDefinitionArray,
            cancellationToken);
    }
}
