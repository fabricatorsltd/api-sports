using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Basketball.Models;

public sealed class GameTeamStatistics
{
    [JsonPropertyName("game")]
    public GameRef? Game { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("field_goals")]
    public ShootingStat? FieldGoals { get; init; }

    [JsonPropertyName("threepoint_goals")]
    public ShootingStat? ThreePointGoals { get; init; }

    [JsonPropertyName("freethrows_goals")]
    public ShootingStat? FreeThrowsGoals { get; init; }

    [JsonPropertyName("rebounds")]
    public ReboundStat? Rebounds { get; init; }

    [JsonPropertyName("assists")]
    public int? Assists { get; init; }

    [JsonPropertyName("steals")]
    public int? Steals { get; init; }

    [JsonPropertyName("blocks")]
    public int? Blocks { get; init; }

    [JsonPropertyName("turnovers")]
    public int? Turnovers { get; init; }

    [JsonPropertyName("personal_fouls")]
    public int? PersonalFouls { get; init; }
}

public sealed class GamePlayerStatistics
{
    [JsonPropertyName("game")]
    public GameRef? Game { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("player")]
    public PlayerRef? Player { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("minutes")]
    public string? Minutes { get; init; }

    [JsonPropertyName("field_goals")]
    public ShootingStat? FieldGoals { get; init; }

    [JsonPropertyName("threepoint_goals")]
    public ShootingStat? ThreePointGoals { get; init; }

    [JsonPropertyName("freethrows_goals")]
    public ShootingStat? FreeThrowsGoals { get; init; }

    [JsonPropertyName("rebounds")]
    public ReboundStat? Rebounds { get; init; }

    [JsonPropertyName("assists")]
    public int? Assists { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }
}

public sealed class PlayerRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class ShootingStat
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("attempts")]
    public int? Attempts { get; init; }

    [JsonPropertyName("percentage")]
    public int? Percentage { get; init; }
}

public sealed class ReboundStat
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("offence")]
    public int? Offence { get; init; }

    [JsonPropertyName("defense")]
    public int? Defense { get; init; }
}
