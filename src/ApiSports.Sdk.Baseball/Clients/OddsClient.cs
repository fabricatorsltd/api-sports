using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Baseball.Json;
using ApiSports.Sdk.Baseball.Models;
using ApiSports.Sdk.Baseball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Baseball.Clients;

public sealed class OddsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<OddsResponse[]>> GetAsync(
        OddsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseOddsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<BetDefinition[]>> GetBetsAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bets",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseBetDefinitionArray,
            cancellationToken);
    }

    public Task<ApiResponse<BookmakerDefinition[]>> GetBookmakersAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bookmakers",
            query,
            BaseballJsonSerializerContext.Default.ApiResponseBookmakerDefinitionArray,
            cancellationToken);
    }
}
