using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class Player
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("age")]
    public int? Age { get; init; }

    [JsonPropertyName("height")]
    public string? Height { get; init; }

    [JsonPropertyName("weight")]
    public string? Weight { get; init; }

    [JsonPropertyName("college")]
    public string? College { get; init; }

    [JsonPropertyName("group")]
    public string? Group { get; init; }

    [JsonPropertyName("position")]
    public string? Position { get; init; }

    [JsonPropertyName("number")]
    public int? Number { get; init; }

    [JsonPropertyName("salary")]
    public string? Salary { get; init; }

    [JsonPropertyName("experience")]
    public int? Experience { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }
}

public sealed class PlayerSummary
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }
}

public sealed class PlayerSeasonStatistics
{
    [JsonPropertyName("player")]
    public PlayerSummary? Player { get; init; }

    [JsonPropertyName("teams")]
    public PlayerSeasonTeamStatistics[]? Teams { get; init; }
}

public sealed class PlayerSeasonTeamStatistics
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("groups")]
    public PlayerStatisticsGroup[]? Groups { get; init; }
}

public sealed class PlayerStatisticsGroup
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("statistics")]
    public NamedStatistic[]? Statistics { get; init; }
}

public sealed class NamedStatistic
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }
}
