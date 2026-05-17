using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Afl.Json;
using ApiSports.Sdk.Afl.Models;
using ApiSports.Sdk.Afl.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Afl.Clients;

public sealed class OddsClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<OddsResponse[]>> GetAsync(
        OddsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds",
            query,
            AflJsonSerializerContext.Default.ApiResponseOddsResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<BetDefinition[]>> GetBetsAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bets",
            query,
            AflJsonSerializerContext.Default.ApiResponseBetDefinitionArray,
            cancellationToken);
    }

    public Task<ApiResponse<BookmakerDefinition[]>> GetBookmakersAsync(
        OddsCatalogQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/odds/bookmakers",
            query,
            AflJsonSerializerContext.Default.ApiResponseBookmakerDefinitionArray,
            cancellationToken);
    }
}
