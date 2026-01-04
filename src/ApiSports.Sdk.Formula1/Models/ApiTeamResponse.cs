using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiTeamResponse
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("base")]
    public string? Base { get; init; }

    [JsonPropertyName("first_team_entry")]
    public int? FirstTeamEntry { get; init; }

    [JsonPropertyName("world_championships")]
    public int? WorldChampionships { get; init; }

    [JsonPropertyName("highest_race_finish")]
    public HighestRaceFinish? HighestRaceFinish { get; init; }

    [JsonPropertyName("pole_positions")]
    public int? PolePositions { get; init; }

    [JsonPropertyName("fastest_laps")]
    public int? FastestLaps { get; init; }

    [JsonPropertyName("president")]
    public string? President { get; init; }

    [JsonPropertyName("director")]
    public string? Director { get; init; }

    [JsonPropertyName("technical_manager")]
    public string? TechnicalManager { get; init; }

    [JsonPropertyName("chassis")]
    public string? Chassis { get; init; }

    [JsonPropertyName("engine")]
    public string? Engine { get; init; }

    [JsonPropertyName("tyres")]
    public string? Tyres { get; init; }
}
