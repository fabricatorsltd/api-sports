using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;

namespace ApiSports.Sdk.Core.Json;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(ApiResponse<StatusResponse>))]
public sealed partial class ApiSportsCommonJsonContext : JsonSerializerContext
{
}
