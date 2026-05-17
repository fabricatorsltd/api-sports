using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class GamePlayerStatisticsResponse
{
    [JsonPropertyName("game")]
    public GameRef? GameRef { get; init; }

    [JsonPropertyName("teams")]
    public GamePlayerStatisticsTeam[]? Teams { get; init; }
}

public sealed class GamePlayerStatisticsTeam
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("players")]
    public GamePlayerStatistics[]? Players { get; init; }
}

public sealed class GamePlayerStatistics
{
    [JsonPropertyName("player")]
    public GamePlayerRef? Player { get; init; }

    [JsonPropertyName("goals")]
    public GamePlayerGoals? Goals { get; init; }

    [JsonPropertyName("behinds")]
    public int? Behinds { get; init; }

    [JsonPropertyName("disposals")]
    public int? Disposals { get; init; }

    [JsonPropertyName("kicks")]
    public int? Kicks { get; init; }

    [JsonPropertyName("handballs")]
    public int? Handballs { get; init; }

    [JsonPropertyName("marks")]
    public int? Marks { get; init; }

    [JsonPropertyName("tackles")]
    public int? Tackles { get; init; }

    [JsonPropertyName("hitouts")]
    public int? HitOuts { get; init; }

    [JsonPropertyName("clearances")]
    public int? Clearances { get; init; }

    [JsonPropertyName("free_kicks")]
    public GamePlayerFreeKicks? FreeKicks { get; init; }
}

public sealed class GamePlayerRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("number")]
    public int? Number { get; init; }
}

public sealed class GamePlayerGoals
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("assists")]
    public int? Assists { get; init; }
}

public sealed class GamePlayerFreeKicks
{
    [JsonPropertyName("for")]
    public int? For { get; init; }

    [JsonPropertyName("against")]
    public int? Against { get; init; }
}
