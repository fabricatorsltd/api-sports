using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Tests.Serialization;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<Status>))]
[JsonSerializable(typeof(ApiResponse<ApiLeagueResponse[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
[JsonSerializable(typeof(ApiResponse<ApiTeamResponse[]>))]
[JsonSerializable(typeof(ApiResponse<TeamStatisticsResponse>))]
[JsonSerializable(typeof(ApiResponse<Country[]>))]
[JsonSerializable(typeof(ApiResponse<FixtureResponse[]>))]
[JsonSerializable(typeof(ApiResponse<string[]>))]
[JsonSerializable(typeof(ApiResponse<HeadToHead[]>))]
[JsonSerializable(typeof(ApiResponse<FixtureStatisticsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<FixtureEvent[]>))]
[JsonSerializable(typeof(ApiResponse<FixtureLineupResponse[]>))]
[JsonSerializable(typeof(ApiResponse<FixturePlayerResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiPlayerResponse[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerProfileResponse[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerSquadResponse[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerTeamResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiPredictionsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsMappingResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsBookmakerResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsBetResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiStandingsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<SidelinedResponse[]>))]
[JsonSerializable(typeof(ApiResponse<Injury[]>))]
[JsonSerializable(typeof(ApiResponse<TransferResponse[]>))]
[JsonSerializable(typeof(ApiResponse<TrophyResponse[]>))]
[JsonSerializable(typeof(ApiResponse<Coach[]>))]
[JsonSerializable(typeof(ApiResponse<Venue[]>))]
public sealed partial class FootballJsonContext : JsonSerializerContext;
