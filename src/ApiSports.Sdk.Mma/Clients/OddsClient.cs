using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Mma.Json;
using ApiSports.Sdk.Mma.Models;
using ApiSports.Sdk.Mma.QueryParams;

namespace ApiSports.Sdk.Mma.Clients;

public sealed class OddsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<OddsResponse[]>> GetAsync(
        OddsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds",
            query,
            MmaJsonSerializerContext.Default.ApiResponseOddsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<BetDefinition[]>> GetBetsAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bets",
            query,
            MmaJsonSerializerContext.Default.ApiResponseBetDefinitionArray,
            cancellationToken);
    }

    public Task<ApiResponse<BookmakerDefinition[]>> GetBookmakersAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bookmakers",
            query,
            MmaJsonSerializerContext.Default.ApiResponseBookmakerDefinitionArray,
            cancellationToken);
    }
}
