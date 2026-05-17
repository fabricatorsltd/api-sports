using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Afl.Models;

namespace ApiSports.Sdk.Afl.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<StatusResponse>))]
[JsonSerializable(typeof(ApiResponse<string[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
[JsonSerializable(typeof(ApiResponse<League[]>))]
[JsonSerializable(typeof(ApiResponse<Team[]>))]
[JsonSerializable(typeof(ApiResponse<TeamStatisticsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<Standing[]>))]
[JsonSerializable(typeof(ApiResponse<Game[]>))]
[JsonSerializable(typeof(ApiResponse<GameEventsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<GameQuartersResponse[]>))]
[JsonSerializable(typeof(ApiResponse<GameTeamStatisticsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<GamePlayerStatisticsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<Player[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerStatisticsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<BetDefinition[]>))]
[JsonSerializable(typeof(ApiResponse<BookmakerDefinition[]>))]
public sealed partial class AflJsonSerializerContext : JsonSerializerContext;
