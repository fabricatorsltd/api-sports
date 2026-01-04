using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class RaceFastestLap
{
    [JsonPropertyName("driver")]
    public RaceFastestLapDriver? Driver { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }
}