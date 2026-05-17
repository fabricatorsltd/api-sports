using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class GameTeamStatistics
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("statistics")]
    public GameTeamStatisticsLine? Statistics { get; init; }
}

public sealed class GameTeamStatisticsLine
{
    [JsonPropertyName("first_downs")]
    public FirstDownsBreakdown? FirstDowns { get; init; }

    [JsonPropertyName("plays")]
    public PlaysBreakdown? Plays { get; init; }

    [JsonPropertyName("yards")]
    public YardsBreakdown? Yards { get; init; }

    [JsonPropertyName("passing")]
    public PassingBreakdown? Passing { get; init; }

    [JsonPropertyName("rushings")]
    public RushingsBreakdown? Rushings { get; init; }

    [JsonPropertyName("red_zone")]
    public RedZoneBreakdown? RedZone { get; init; }

    [JsonPropertyName("penalties")]
    public TotalString? Penalties { get; init; }

    [JsonPropertyName("turnovers")]
    public TurnoversBreakdown? Turnovers { get; init; }

    // Upstream field is misspelled ("posession") — preserve to deserialize correctly.
    [JsonPropertyName("posession")]
    public TotalString? Possession { get; init; }

    [JsonPropertyName("interceptions")]
    public TotalInt? Interceptions { get; init; }

    [JsonPropertyName("fumbles_recovered")]
    public TotalInt? FumblesRecovered { get; init; }

    [JsonPropertyName("sacks")]
    public TotalInt? Sacks { get; init; }

    [JsonPropertyName("safeties")]
    public TotalInt? Safeties { get; init; }

    [JsonPropertyName("int_touchdowns")]
    public TotalInt? InterceptionTouchdowns { get; init; }

    [JsonPropertyName("points_against")]
    public TotalInt? PointsAgainst { get; init; }
}

public sealed class FirstDownsBreakdown
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("passing")]
    public int? Passing { get; init; }

    [JsonPropertyName("rushing")]
    public int? Rushing { get; init; }

    [JsonPropertyName("from_penalties")]
    public int? FromPenalties { get; init; }

    [JsonPropertyName("third_down_efficiency")]
    public string? ThirdDownEfficiency { get; init; }

    [JsonPropertyName("fourth_down_efficiency")]
    public string? FourthDownEfficiency { get; init; }
}

public sealed class PlaysBreakdown
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }
}

public sealed class YardsBreakdown
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("yards_per_play")]
    public string? YardsPerPlay { get; init; }

    [JsonPropertyName("total_drives")]
    public string? TotalDrives { get; init; }
}

public sealed class PassingBreakdown
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("comp_att")]
    public string? CompletionsAttempts { get; init; }

    [JsonPropertyName("yards_per_pass")]
    public string? YardsPerPass { get; init; }

    [JsonPropertyName("interceptions_thrown")]
    public int? InterceptionsThrown { get; init; }

    [JsonPropertyName("sacks_yards_lost")]
    public string? SacksYardsLost { get; init; }
}

public sealed class RushingsBreakdown
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("attempts")]
    public int? Attempts { get; init; }

    [JsonPropertyName("yards_per_rush")]
    public string? YardsPerRush { get; init; }
}

public sealed class RedZoneBreakdown
{
    [JsonPropertyName("made_att")]
    public string? MadeAttempted { get; init; }
}

public sealed class TurnoversBreakdown
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("lost_fumbles")]
    public int? LostFumbles { get; init; }

    [JsonPropertyName("interceptions")]
    public int? Interceptions { get; init; }
}

public sealed class TotalInt
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }
}

public sealed class TotalString
{
    [JsonPropertyName("total")]
    public string? Total { get; init; }
}

public sealed class GamePlayerStatistics
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("groups")]
    public GamePlayerStatisticsGroup[]? Groups { get; init; }
}

public sealed class GamePlayerStatisticsGroup
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("players")]
    public GamePlayerStatisticsEntry[]? Players { get; init; }
}

public sealed class GamePlayerStatisticsEntry
{
    [JsonPropertyName("player")]
    public PlayerSummary? Player { get; init; }

    [JsonPropertyName("statistics")]
    public NamedStatistic[]? Statistics { get; init; }
}
