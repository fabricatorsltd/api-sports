using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class GameTeamStatisticsResponse
{
    [JsonPropertyName("game")]
    public GameRef? GameRef { get; init; }

    [JsonPropertyName("teams")]
    public GameTeamStatistics[]? Teams { get; init; }
}

public sealed class GameTeamStatistics
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("statistics")]
    public GameTeamStatisticsBreakdown? Statistics { get; init; }
}

public sealed class GameTeamStatisticsBreakdown
{
    [JsonPropertyName("disposals")]
    public GameTeamStatisticsDisposals? Disposals { get; init; }

    [JsonPropertyName("stoppages")]
    public GameTeamStatisticsStoppages? Stoppages { get; init; }

    [JsonPropertyName("marks")]
    public int? Marks { get; init; }

    [JsonPropertyName("scoring")]
    public GameTeamStatisticsScoring? Scoring { get; init; }

    [JsonPropertyName("defence")]
    public GameTeamStatisticsDefence? Defence { get; init; }
}

public sealed class GameTeamStatisticsDisposals
{
    [JsonPropertyName("disposals")]
    public int? Disposals { get; init; }

    [JsonPropertyName("kicks")]
    public int? Kicks { get; init; }

    [JsonPropertyName("handballs")]
    public int? Handballs { get; init; }

    [JsonPropertyName("free_kicks")]
    public int? FreeKicks { get; init; }
}

public sealed class GameTeamStatisticsStoppages
{
    [JsonPropertyName("hitouts")]
    public int? HitOuts { get; init; }

    [JsonPropertyName("clearances")]
    public int? Clearances { get; init; }
}

public sealed class GameTeamStatisticsScoring
{
    [JsonPropertyName("goals")]
    public int? Goals { get; init; }

    [JsonPropertyName("assists")]
    public int? Assists { get; init; }

    [JsonPropertyName("behinds")]
    public int? Behinds { get; init; }
}

public sealed class GameTeamStatisticsDefence
{
    [JsonPropertyName("tackles")]
    public int? Tackles { get; init; }
}
