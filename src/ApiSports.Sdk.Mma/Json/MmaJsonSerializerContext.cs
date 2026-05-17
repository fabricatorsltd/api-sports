using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Mma.Models;

namespace ApiSports.Sdk.Mma.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<StatusResponse>))]
[JsonSerializable(typeof(ApiResponse<string[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
[JsonSerializable(typeof(ApiResponse<Team[]>))]
[JsonSerializable(typeof(ApiResponse<Fighter[]>))]
[JsonSerializable(typeof(ApiResponse<FighterRecord[]>))]
[JsonSerializable(typeof(ApiResponse<Fight[]>))]
[JsonSerializable(typeof(ApiResponse<FightResult[]>))]
[JsonSerializable(typeof(ApiResponse<FightStatistics[]>))]
[JsonSerializable(typeof(ApiResponse<OddsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<BetDefinition[]>))]
[JsonSerializable(typeof(ApiResponse<BookmakerDefinition[]>))]
public sealed partial class MmaJsonSerializerContext : JsonSerializerContext;
