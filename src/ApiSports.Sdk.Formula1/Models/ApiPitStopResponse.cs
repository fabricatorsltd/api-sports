using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiPitStopResponse
{
    [JsonPropertyName("race")]
    public RaceIdentifier? Race { get; init; }

    [JsonPropertyName("driver")]
    public DriverSummary? Driver { get; init; }

    [JsonPropertyName("team")]
    public TeamSummary? Team { get; init; }

    [JsonPropertyName("stops")]
    public int? Stops { get; init; }

    [JsonPropertyName("lap")]
    public int? Lap { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("total_time")]
    public string? TotalTime { get; init; }
}