using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Volleyball.Models;

public sealed class Standing
{
    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("stage")]
    public string? Stage { get; init; }

    [JsonPropertyName("group")]
    public StandingGroup? Group { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("league")]
    public LeagueRef? League { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }

    [JsonPropertyName("games")]
    public StandingGames? Games { get; init; }

    [JsonPropertyName("goals")]
    public StandingGoals? Goals { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }

    [JsonPropertyName("form")]
    public string? Form { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}

public sealed class StandingGroup
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class StandingGames
{
    [JsonPropertyName("played")]
    public int? Played { get; init; }

    [JsonPropertyName("win")]
    public StandingResult? Win { get; init; }

    [JsonPropertyName("lose")]
    public StandingResult? Lose { get; init; }
}

public sealed class StandingResult
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("percentage")]
    public string? Percentage { get; init; }
}

public sealed class StandingGoals
{
    [JsonPropertyName("for")]
    public int? For { get; init; }

    [JsonPropertyName("against")]
    public int? Against { get; init; }
}
