using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Football.Models;

namespace ApiSports.Sdk.Football.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<FixtureResponse[]>))]
[JsonSerializable(typeof(ApiResponse<string[]>))]
[JsonSerializable(typeof(ApiResponse<HeadToHead[]>))]
[JsonSerializable(typeof(ApiResponse<FixtureStatisticsResponse[]>))]
[JsonSerializable(typeof(ApiResponse<FixtureEvent[]>))]
[JsonSerializable(typeof(ApiResponse<FixtureLineupResponse[]>))]
[JsonSerializable(typeof(ApiResponse<FixturePlayerResponse[]>))]
public sealed partial class FixturesJsonContext : JsonSerializerContext;
