using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class LapRecord
{
    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("driver")]
    public string? Driver { get; init; }

    [JsonPropertyName("year")]
    public string? Year { get; init; }
}