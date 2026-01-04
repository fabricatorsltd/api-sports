using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiRaceRankingResponse
{
    [JsonPropertyName("race")]
    public RaceIdentifier? Race { get; init; }

    [JsonPropertyName("driver")]
    public DriverSummary? Driver { get; init; }

    [JsonPropertyName("team")]
    public TeamSummary? Team { get; init; }

    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("laps")]
    public int? Laps { get; init; }

    [JsonPropertyName("grid")]
    public string? Grid { get; init; }

    [JsonPropertyName("pits")]
    public int? Pits { get; init; }

    [JsonPropertyName("gap")]
    public string? Gap { get; init; }
}