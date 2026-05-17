using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Hockey.Json;
using ApiSports.Sdk.Hockey.Models;
using ApiSports.Sdk.Hockey.QueryParams;

namespace ApiSports.Sdk.Hockey.Clients;

public sealed class OddsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<OddsResponse[]>> GetAsync(
        OddsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseOddsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<BetDefinition[]>> GetBetsAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bets",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseBetDefinitionArray,
            cancellationToken);
    }

    public Task<ApiResponse<BookmakerDefinition[]>> GetBookmakersAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bookmakers",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseBookmakerDefinitionArray,
            cancellationToken);
    }
}
