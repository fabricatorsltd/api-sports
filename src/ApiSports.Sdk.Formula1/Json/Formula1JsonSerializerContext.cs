using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Formula1.Models;

namespace ApiSports.Sdk.Formula1.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<string[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
[JsonSerializable(typeof(ApiResponse<ApiCompetitionResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiCircuitResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiTeamResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiDriverResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiRaceResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiTeamRankingResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiDriverRankingResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiRaceRankingResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiFastestLapRankingResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiStartingGridRankingResponse[]>))]
[JsonSerializable(typeof(ApiResponse<ApiPitStopResponse[]>))]
public sealed partial class Formula1JsonSerializerContext : JsonSerializerContext;
