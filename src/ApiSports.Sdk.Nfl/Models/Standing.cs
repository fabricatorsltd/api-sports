using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class Standing
{
    [JsonPropertyName("league")]
    public LeagueRef? League { get; init; }

    [JsonPropertyName("conference")]
    public string? Conference { get; init; }

    [JsonPropertyName("division")]
    public string? Division { get; init; }

    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("won")]
    public int? Won { get; init; }

    [JsonPropertyName("lost")]
    public int? Lost { get; init; }

    [JsonPropertyName("ties")]
    public int? Ties { get; init; }

    [JsonPropertyName("points")]
    public StandingPoints? Points { get; init; }

    [JsonPropertyName("records")]
    public StandingRecords? Records { get; init; }

    [JsonPropertyName("streak")]
    public string? Streak { get; init; }

    [JsonPropertyName("ncaa_conference")]
    public StandingNcaaConference? NcaaConference { get; init; }
}

public sealed class StandingPoints
{
    [JsonPropertyName("for")]
    public int? For { get; init; }

    [JsonPropertyName("against")]
    public int? Against { get; init; }

    [JsonPropertyName("difference")]
    public int? Difference { get; init; }
}

public sealed class StandingRecords
{
    [JsonPropertyName("home")]
    public string? Home { get; init; }

    [JsonPropertyName("road")]
    public string? Road { get; init; }

    [JsonPropertyName("conference")]
    public string? Conference { get; init; }

    [JsonPropertyName("division")]
    public string? Division { get; init; }
}

public sealed class StandingNcaaConference
{
    [JsonPropertyName("won")]
    public int? Won { get; init; }

    [JsonPropertyName("lost")]
    public int? Lost { get; init; }

    [JsonPropertyName("points")]
    public StandingNcaaPoints? Points { get; init; }
}

public sealed class StandingNcaaPoints
{
    [JsonPropertyName("for")]
    public int? For { get; init; }

    [JsonPropertyName("against")]
    public int? Against { get; init; }
}
