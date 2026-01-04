using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiDriverResponse
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("abbr")]
    public string? Abbr { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }

    [JsonPropertyName("nationality")]
    public string? Nationality { get; init; }

    [JsonPropertyName("country")]
    public DriverCountry? Country { get; init; }

    [JsonPropertyName("birthdate")]
    public string? Birthdate { get; init; }

    [JsonPropertyName("birthplace")]
    public string? Birthplace { get; init; }

    [JsonPropertyName("number")]
    public int? Number { get; init; }

    [JsonPropertyName("grands_prix_entered")]
    public int? GrandsPrixEntered { get; init; }

    [JsonPropertyName("world_championships")]
    public int? WorldChampionships { get; init; }

    [JsonPropertyName("podiums")]
    public int? Podiums { get; init; }

    [JsonPropertyName("highest_race_finish")]
    public HighestRaceFinish? HighestRaceFinish { get; init; }

    [JsonPropertyName("highest_grid_position")]
    public int? HighestGridPosition { get; init; }

    [JsonPropertyName("career_points")]
    public string? CareerPoints { get; init; }

    [JsonPropertyName("teams")]
    public DriverTeamSeason[]? Teams { get; init; }
}
