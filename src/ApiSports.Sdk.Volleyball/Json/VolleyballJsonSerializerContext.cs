using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;
using ApiSports.Sdk.Volleyball.Models;

namespace ApiSports.Sdk.Volleyball.Json;

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
public sealed partial class VolleyballJsonSerializerContext : JsonSerializerContext;
