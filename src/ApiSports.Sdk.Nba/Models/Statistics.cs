using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nba.Models;

public sealed class TeamSeasonStatistics
{
    [JsonPropertyName("games")]
    public int? Games { get; init; }

    [JsonPropertyName("fastBreakPoints")]
    public int? FastBreakPoints { get; init; }

    [JsonPropertyName("pointsInPaint")]
    public int? PointsInPaint { get; init; }

    [JsonPropertyName("biggestLead")]
    public int? BiggestLead { get; init; }

    [JsonPropertyName("secondChancePoints")]
    public int? SecondChancePoints { get; init; }

    [JsonPropertyName("pointsOffTurnovers")]
    public int? PointsOffTurnovers { get; init; }

    [JsonPropertyName("longestRun")]
    public int? LongestRun { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }

    [JsonPropertyName("fgm")]
    public int? FieldGoalsMade { get; init; }

    [JsonPropertyName("fga")]
    public int? FieldGoalsAttempted { get; init; }

    [JsonPropertyName("fgp")]
    public string? FieldGoalsPercentage { get; init; }

    [JsonPropertyName("ftm")]
    public int? FreeThrowsMade { get; init; }

    [JsonPropertyName("fta")]
    public int? FreeThrowsAttempted { get; init; }

    [JsonPropertyName("ftp")]
    public string? FreeThrowsPercentage { get; init; }

    [JsonPropertyName("tpm")]
    public int? ThreePointersMade { get; init; }

    [JsonPropertyName("tpa")]
    public int? ThreePointersAttempted { get; init; }

    [JsonPropertyName("tpp")]
    public string? ThreePointersPercentage { get; init; }

    [JsonPropertyName("offReb")]
    public int? OffensiveRebounds { get; init; }

    [JsonPropertyName("defReb")]
    public int? DefensiveRebounds { get; init; }

    [JsonPropertyName("totReb")]
    public int? TotalRebounds { get; init; }

    [JsonPropertyName("assists")]
    public int? Assists { get; init; }

    [JsonPropertyName("pFouls")]
    public int? PersonalFouls { get; init; }

    [JsonPropertyName("steals")]
    public int? Steals { get; init; }

    [JsonPropertyName("turnovers")]
    public int? Turnovers { get; init; }

    [JsonPropertyName("blocks")]
    public int? Blocks { get; init; }

    [JsonPropertyName("plusMinus")]
    public int? PlusMinus { get; init; }

    [JsonPropertyName("min")]
    public string? Minutes { get; init; }
}

public sealed class GameTeamStatistics
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("statistics")]
    public GameTeamStatisticsLine[]? Statistics { get; init; }
}

public sealed class GameTeamStatisticsLine
{
    [JsonPropertyName("fastBreakPoints")]
    public int? FastBreakPoints { get; init; }

    [JsonPropertyName("pointsInPaint")]
    public int? PointsInPaint { get; init; }

    [JsonPropertyName("biggestLead")]
    public int? BiggestLead { get; init; }

    [JsonPropertyName("secondChancePoints")]
    public int? SecondChancePoints { get; init; }

    [JsonPropertyName("pointsOffTurnovers")]
    public int? PointsOffTurnovers { get; init; }

    [JsonPropertyName("longestRun")]
    public int? LongestRun { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }

    [JsonPropertyName("fgm")]
    public int? FieldGoalsMade { get; init; }

    [JsonPropertyName("fga")]
    public int? FieldGoalsAttempted { get; init; }

    [JsonPropertyName("fgp")]
    public string? FieldGoalsPercentage { get; init; }

    [JsonPropertyName("ftm")]
    public int? FreeThrowsMade { get; init; }

    [JsonPropertyName("fta")]
    public int? FreeThrowsAttempted { get; init; }

    [JsonPropertyName("ftp")]
    public string? FreeThrowsPercentage { get; init; }

    [JsonPropertyName("tpm")]
    public int? ThreePointersMade { get; init; }

    [JsonPropertyName("tpa")]
    public int? ThreePointersAttempted { get; init; }

    [JsonPropertyName("tpp")]
    public string? ThreePointersPercentage { get; init; }

    [JsonPropertyName("offReb")]
    public int? OffensiveRebounds { get; init; }

    [JsonPropertyName("defReb")]
    public int? DefensiveRebounds { get; init; }

    [JsonPropertyName("totReb")]
    public int? TotalRebounds { get; init; }

    [JsonPropertyName("assists")]
    public int? Assists { get; init; }

    [JsonPropertyName("pFouls")]
    public int? PersonalFouls { get; init; }

    [JsonPropertyName("steals")]
    public int? Steals { get; init; }

    [JsonPropertyName("turnovers")]
    public int? Turnovers { get; init; }

    [JsonPropertyName("blocks")]
    public int? Blocks { get; init; }

    [JsonPropertyName("plusMinus")]
    public string? PlusMinus { get; init; }

    [JsonPropertyName("min")]
    public string? Minutes { get; init; }
}

public sealed class PlayerGameStatistics
{
    [JsonPropertyName("player")]
    public PlayerRef? Player { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("game")]
    public GameRef? Game { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }

    [JsonPropertyName("pos")]
    public string? Position { get; init; }

    [JsonPropertyName("min")]
    public string? Minutes { get; init; }

    [JsonPropertyName("fgm")]
    public int? FieldGoalsMade { get; init; }

    [JsonPropertyName("fga")]
    public int? FieldGoalsAttempted { get; init; }

    [JsonPropertyName("fgp")]
    public string? FieldGoalsPercentage { get; init; }

    [JsonPropertyName("ftm")]
    public int? FreeThrowsMade { get; init; }

    [JsonPropertyName("fta")]
    public int? FreeThrowsAttempted { get; init; }

    [JsonPropertyName("ftp")]
    public string? FreeThrowsPercentage { get; init; }

    [JsonPropertyName("tpm")]
    public int? ThreePointersMade { get; init; }

    [JsonPropertyName("tpa")]
    public int? ThreePointersAttempted { get; init; }

    [JsonPropertyName("tpp")]
    public string? ThreePointersPercentage { get; init; }

    [JsonPropertyName("offReb")]
    public int? OffensiveRebounds { get; init; }

    [JsonPropertyName("defReb")]
    public int? DefensiveRebounds { get; init; }

    [JsonPropertyName("totReb")]
    public int? TotalRebounds { get; init; }

    [JsonPropertyName("assists")]
    public int? Assists { get; init; }

    [JsonPropertyName("pFouls")]
    public int? PersonalFouls { get; init; }

    [JsonPropertyName("steals")]
    public int? Steals { get; init; }

    [JsonPropertyName("turnovers")]
    public int? Turnovers { get; init; }

    [JsonPropertyName("blocks")]
    public int? Blocks { get; init; }

    [JsonPropertyName("plusMinus")]
    public string? PlusMinus { get; init; }

    [JsonPropertyName("comment")]
    public string? Comment { get; init; }
}
