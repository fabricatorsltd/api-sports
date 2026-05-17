using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Basketball.Json;
using ApiSports.Sdk.Basketball.Models;
using ApiSports.Sdk.Basketball.QueryParams;
using ApiSports.Sdk.Core;

namespace ApiSports.Sdk.Basketball.Clients;

public sealed class PlayersClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<Player[]>> GetAsync(
        PlayersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players",
            query,
            BasketballJsonSerializerContext.Default.ApiResponsePlayerArray,
            cancellationToken);
    }
}
