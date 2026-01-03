using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<ApiTeamResponse[]>))]
[JsonSerializable(typeof(ApiResponse<int[]>))]
public sealed partial class TeamsJsonContext : JsonSerializerContext;
