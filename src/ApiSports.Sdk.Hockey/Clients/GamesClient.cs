using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Hockey.Json;
using ApiSports.Sdk.Hockey.Models;
using ApiSports.Sdk.Hockey.QueryParams;

namespace ApiSports.Sdk.Hockey.Clients;

public sealed class GamesClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Game[]>> GetAsync(
        GamesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<Game[]>> GetHeadToHeadAsync(
        GamesHeadToHeadQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/h2h",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseGameArray,
            cancellationToken);
    }

    public Task<ApiResponse<GameEvent[]>> GetEventsAsync(
        GamesEventsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/games/events",
            query,
            HockeyJsonSerializerContext.Default.ApiResponseGameEventArray,
            cancellationToken);
    }
}
