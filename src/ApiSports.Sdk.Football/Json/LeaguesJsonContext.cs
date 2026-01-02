using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<ApiLeagueResponse[]>))]
public sealed partial class LeaguesJsonContext : JsonSerializerContext;
