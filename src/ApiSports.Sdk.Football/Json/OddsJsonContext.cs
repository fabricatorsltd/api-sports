using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<OddsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsMappingResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsBookmakerResponse[]>))]
[JsonSerializable(typeof(ApiResponse<OddsBetResponse[]>))]
public sealed partial class OddsJsonContext : JsonSerializerContext;
