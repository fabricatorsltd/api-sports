using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Core;
using ApiSports.Sdk.Football.Json;
using ApiSports.Sdk.Football.Models;
using ApiSports.Sdk.Football.QueryParams;

namespace ApiSports.Sdk.Football.Clients;

public sealed class PlayersClient(ApiSportsHttpClient http)
{
    public Task<ApiResponse<ApiPlayerResponse[]>> GetAsync(
        PlayersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players",
            query,
            PlayersJsonContext.Default.ApiResponseApiPlayerResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<int[]>> GetSeasonsAsync(
        PlayersSeasonsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/seasons",
            query,
            PlayersJsonContext.Default.ApiResponseInt32Array,
            cancellationToken);
    }

    public Task<ApiResponse<PlayerProfileResponse[]>> GetProfilesAsync(
        PlayersProfilesQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/profiles",
            query,
            PlayersJsonContext.Default.ApiResponsePlayerProfileResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<PlayerSquadResponse[]>> GetSquadsAsync(
        PlayersSquadsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/squads",
            query,
            PlayersJsonContext.Default.ApiResponsePlayerSquadResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<PlayerTeamResponse[]>> GetTeamsAsync(
        PlayersTeamsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/teams",
            query,
            PlayersJsonContext.Default.ApiResponsePlayerTeamResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiPlayerResponse[]>> GetTopScorersAsync(
        PlayersTopScorersQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/topscorers",
            query,
            PlayersJsonContext.Default.ApiResponseApiPlayerResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiPlayerResponse[]>> GetTopAssistsAsync(
        PlayersTopAssistsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/topassists",
            query,
            PlayersJsonContext.Default.ApiResponseApiPlayerResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiPlayerResponse[]>> GetTopYellowCardsAsync(
        PlayersTopYellowCardsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/topyellowcards",
            query,
            PlayersJsonContext.Default.ApiResponseApiPlayerResponseArray,
            cancellationToken);
    }

    public Task<ApiResponse<ApiPlayerResponse[]>> GetTopRedCardsAsync(
        PlayersTopRedCardsQuery query,
        CancellationToken cancellationToken = default)
    {
        return http.GetAsync(
            "/players/topredcards",
            query,
            PlayersJsonContext.Default.ApiResponseApiPlayerResponseArray,
            cancellationToken);
    }
}
