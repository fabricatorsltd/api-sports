using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
namespace ApiSports.Sdk.Football.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(ApiResponse<string[]>))]
public sealed partial class TimezoneJsonContext : JsonSerializerContext;
