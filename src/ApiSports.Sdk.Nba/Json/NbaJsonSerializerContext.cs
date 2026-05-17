using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Nba.Models;

namespace ApiSports.Sdk.Nba.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<StatusResponse>))]
[JsonSerializable(typeof(ApiResponse<string[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
[JsonSerializable(typeof(ApiResponse<Team[]>))]
[JsonSerializable(typeof(ApiResponse<TeamSeasonStatistics[]>))]
[JsonSerializable(typeof(ApiResponse<Player[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerGameStatistics[]>))]
[JsonSerializable(typeof(ApiResponse<Game[]>))]
[JsonSerializable(typeof(ApiResponse<GameTeamStatistics[]>))]
[JsonSerializable(typeof(ApiResponse<Standing[]>))]
public sealed partial class NbaJsonSerializerContext : JsonSerializerContext;
