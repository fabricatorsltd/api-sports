using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Hockey.Models;

public sealed class TeamStatisticsResponse
{
    [JsonPropertyName("country")]
    public Country? Country { get; init; }

    [JsonPropertyName("league")]
    public LeagueRef? League { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("games")]
    public TeamStatisticsGames? Games { get; init; }

    [JsonPropertyName("goals")]
    public TeamStatisticsGoals? Goals { get; init; }
}

public sealed class TeamStatisticsGames
{
    [JsonPropertyName("played")]
    public StatHomeAwayAll<int?>? Played { get; init; }

    [JsonPropertyName("wins")]
    public StatHomeAwayAll<StatTotalPercentage>? Wins { get; init; }

    [JsonPropertyName("loses")]
    public StatHomeAwayAll<StatTotalPercentage>? Loses { get; init; }
}

public sealed class TeamStatisticsGoals
{
    [JsonPropertyName("for")]
    public TeamStatisticsGoalsBreakdown? For { get; init; }

    [JsonPropertyName("against")]
    public TeamStatisticsGoalsBreakdown? Against { get; init; }
}

public sealed class TeamStatisticsGoalsBreakdown
{
    [JsonPropertyName("total")]
    public StatHomeAwayAll<int?>? Total { get; init; }

    [JsonPropertyName("average")]
    public StatHomeAwayAll<string?>? Average { get; init; }
}

public sealed class StatHomeAwayAll<T>
{
    [JsonPropertyName("home")]
    public T? Home { get; init; }

    [JsonPropertyName("away")]
    public T? Away { get; init; }

    [JsonPropertyName("all")]
    public T? All { get; init; }
}

public sealed class StatTotalPercentage
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("percentage")]
    public string? Percentage { get; init; }
}
