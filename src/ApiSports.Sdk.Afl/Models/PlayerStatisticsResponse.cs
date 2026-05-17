using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class PlayerStatisticsResponse
{
    [JsonPropertyName("player")]
    public PlayerRef? Player { get; init; }

    [JsonPropertyName("statistics")]
    public PlayerStatistics? Statistics { get; init; }
}

public sealed class PlayerStatistics
{
    [JsonPropertyName("games")]
    public PlayerStatisticsGames? Games { get; init; }

    [JsonPropertyName("goals")]
    public PlayerStatisticsGoals? Goals { get; init; }

    [JsonPropertyName("behinds")]
    public StatTotalAverage? Behinds { get; init; }

    [JsonPropertyName("disposals")]
    public StatTotalAverage? Disposals { get; init; }

    [JsonPropertyName("kicks")]
    public StatTotalAverage? Kicks { get; init; }

    [JsonPropertyName("handballs")]
    public StatTotalAverage? Handballs { get; init; }

    [JsonPropertyName("marks")]
    public StatTotalAverage? Marks { get; init; }

    [JsonPropertyName("tackles")]
    public StatTotalAverage? Tackles { get; init; }

    [JsonPropertyName("hitouts")]
    public StatTotalAverage? HitOuts { get; init; }

    [JsonPropertyName("clearances")]
    public StatTotalAverage? Clearances { get; init; }

    [JsonPropertyName("free_kicks")]
    public PlayerStatisticsFreeKicks? FreeKicks { get; init; }
}

public sealed class PlayerStatisticsGames
{
    [JsonPropertyName("played")]
    public int? Played { get; init; }
}

public sealed class PlayerStatisticsGoals
{
    [JsonPropertyName("total")]
    public StatTotalAverage? Total { get; init; }

    [JsonPropertyName("assists")]
    public StatTotalAverage? Assists { get; init; }
}

public sealed class PlayerStatisticsFreeKicks
{
    [JsonPropertyName("for")]
    public StatTotalAverage? For { get; init; }

    [JsonPropertyName("against")]
    public StatTotalAverage? Against { get; init; }
}
