using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Volleyball.Json;
using ApiSports.Sdk.Volleyball.Models;
using ApiSports.Sdk.Volleyball.QueryParams;

namespace ApiSports.Sdk.Volleyball.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<Game[]>> GetHeadToHeadAsync(
        GamesHeadToHeadQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/h2h",
            query,
            VolleyballJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }
}
