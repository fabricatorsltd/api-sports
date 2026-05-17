using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nba.Models;

public sealed class Standing
{
    [JsonPropertyName("league")]
    public string? League { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("conference")]
    public StandingConference? Conference { get; init; }

    [JsonPropertyName("division")]
    public StandingDivision? Division { get; init; }

    [JsonPropertyName("win")]
    public StandingRecord? Win { get; init; }

    [JsonPropertyName("loss")]
    public StandingRecord? Loss { get; init; }

    [JsonPropertyName("gamesBehind")]
    public string? GamesBehind { get; init; }

    [JsonPropertyName("streak")]
    public int? Streak { get; init; }

    [JsonPropertyName("winStreak")]
    public bool? WinStreak { get; init; }

    [JsonPropertyName("tieBreakerPoints")]
    public int? TieBreakerPoints { get; init; }
}

public sealed class StandingConference
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("rank")]
    public int? Rank { get; init; }

    [JsonPropertyName("win")]
    public int? Win { get; init; }

    [JsonPropertyName("loss")]
    public int? Loss { get; init; }
}

public sealed class StandingDivision
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("rank")]
    public int? Rank { get; init; }

    [JsonPropertyName("win")]
    public int? Win { get; init; }

    [JsonPropertyName("loss")]
    public int? Loss { get; init; }

    [JsonPropertyName("gamesBehind")]
    public string? GamesBehind { get; init; }
}

public sealed class StandingRecord
{
    [JsonPropertyName("home")]
    public int? Home { get; init; }

    [JsonPropertyName("away")]
    public int? Away { get; init; }

    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("percentage")]
    public string? Percentage { get; init; }

    [JsonPropertyName("lastTen")]
    public int? LastTen { get; init; }
}
