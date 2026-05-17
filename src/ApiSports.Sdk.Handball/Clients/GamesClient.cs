using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Handball.Json;
using ApiSports.Sdk.Handball.Models;
using ApiSports.Sdk.Handball.QueryParams;

namespace ApiSports.Sdk.Handball.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            HandballJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<Game[]>> GetHeadToHeadAsync(
        GamesHeadToHeadQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/h2h",
            query,
            HandballJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }
}
