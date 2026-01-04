using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiFastestLapRankingResponse
{
    [JsonPropertyName("race")]
    public RaceIdentifier? Race { get; init; }

    [JsonPropertyName("driver")]
    public DriverSummary? Driver { get; init; }

    [JsonPropertyName("team")]
    public TeamSummary? Team { get; init; }

    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("lap")]
    public int? Lap { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("avg_speed")]
    public string? AverageSpeed { get; init; }
}