using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Baseball.Models;

namespace ApiSports.Sdk.Baseball.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<StatusResponse>))]
[JsonSerializable(typeof(ApiResponse<string[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
[JsonSerializable(typeof(ApiResponse<Country[]>))]
[JsonSerializable(typeof(ApiResponse<League[]>))]
[JsonSerializable(typeof(ApiResponse<Team[]>))]
[JsonSerializable(typeof(ApiResponse<TeamStatisticsResponse>))]
[JsonSerializable(typeof(ApiResponse<Standing[][]>))]
[JsonSerializable(typeof(ApiResponse<Game[]>))]
[JsonSerializable(typeof(ApiResponse<OddsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<BetDefinition[]>))]
[JsonSerializable(typeof(ApiResponse<BookmakerDefinition[]>))]
public sealed partial class BaseballJsonSerializerContext : JsonSerializerContext;
