using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<ApiPlayerResponse[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerProfileResponse[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerSquadResponse[]>))]
[JsonSerializable(typeof(ApiResponse<PlayerTeamResponse[]>))]
public sealed partial class PlayersJsonContext : JsonSerializerContext;
