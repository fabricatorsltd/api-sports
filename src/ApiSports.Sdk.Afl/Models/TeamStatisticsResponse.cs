using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class TeamStatisticsResponse
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("statistics")]
    public TeamStatistics? Statistics { get; init; }
}

public sealed class TeamStatistics
{
    [JsonPropertyName("games")]
    public TeamStatisticsGames? Games { get; init; }

    [JsonPropertyName("disposals")]
    public TeamStatisticsDisposals? Disposals { get; init; }

    [JsonPropertyName("stoppages")]
    public TeamStatisticsStoppages? Stoppages { get; init; }

    [JsonPropertyName("marks")]
    public StatTotalAverage? Marks { get; init; }

    [JsonPropertyName("scoring")]
    public TeamStatisticsScoring? Scoring { get; init; }

    [JsonPropertyName("defence")]
    public TeamStatisticsDefence? Defence { get; init; }
}

public sealed class TeamStatisticsGames
{
    [JsonPropertyName("played")]
    public int? Played { get; init; }
}

public sealed class TeamStatisticsDisposals
{
    [JsonPropertyName("disposals")]
    public StatTotalAverage? Disposals { get; init; }

    [JsonPropertyName("kicks")]
    public StatTotalAverage? Kicks { get; init; }

    [JsonPropertyName("handballs")]
    public StatTotalAverage? Handballs { get; init; }

    [JsonPropertyName("free_kicks")]
    public StatTotalAverage? FreeKicks { get; init; }
}

public sealed class TeamStatisticsStoppages
{
    [JsonPropertyName("hitouts")]
    public StatTotalAverage? HitOuts { get; init; }

    [JsonPropertyName("clearances")]
    public StatTotalAverage? Clearances { get; init; }
}

public sealed class TeamStatisticsScoring
{
    [JsonPropertyName("goals")]
    public StatTotalAverage? Goals { get; init; }

    [JsonPropertyName("assists")]
    public StatTotalAverage? Assists { get; init; }

    [JsonPropertyName("behinds")]
    public StatTotalAverage? Behinds { get; init; }
}

public sealed class TeamStatisticsDefence
{
    [JsonPropertyName("tackles")]
    public StatTotalAverage? Tackles { get; init; }
}

public sealed class StatTotalAverage
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("average")]
    public string? Average { get; init; }
}
