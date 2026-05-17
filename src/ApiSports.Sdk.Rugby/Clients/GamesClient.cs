using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Rugby.Json;
using ApiSports.Sdk.Rugby.Models;
using ApiSports.Sdk.Rugby.QueryParams;

namespace ApiSports.Sdk.Rugby.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<Game[]>> GetHeadToHeadAsync(
        GamesHeadToHeadQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/h2h",
            query,
            RugbyJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }
}
