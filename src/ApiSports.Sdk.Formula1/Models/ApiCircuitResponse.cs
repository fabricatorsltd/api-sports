using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiCircuitResponse
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }

    [JsonPropertyName("competition")]
    public CompetitionSummary? Competition { get; init; }

    [JsonPropertyName("first_grand_prix")]
    public int? FirstGrandPrix { get; init; }

    [JsonPropertyName("laps")]
    public int? Laps { get; init; }

    [JsonPropertyName("length")]
    public string? Length { get; init; }

    [JsonPropertyName("race_distance")]
    public string? RaceDistance { get; init; }

    [JsonPropertyName("lap_record")]
    public LapRecord? LapRecord { get; init; }

    [JsonPropertyName("capacity")]
    public int? Capacity { get; init; }

    [JsonPropertyName("opened")]
    public int? Opened { get; init; }

    [JsonPropertyName("owner")]
    public string? Owner { get; init; }
}
