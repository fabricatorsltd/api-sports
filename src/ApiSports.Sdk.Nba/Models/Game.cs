using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nba.Models;

public sealed class Game
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("league")]
    public string? League { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }

    [JsonPropertyName("date")]
    public GameDate? Date { get; init; }

    [JsonPropertyName("stage")]
    public int? Stage { get; init; }

    [JsonPropertyName("status")]
    public GameStatus? Status { get; init; }

    [JsonPropertyName("periods")]
    public GamePeriods? Periods { get; init; }

    [JsonPropertyName("arena")]
    public GameArena? Arena { get; init; }

    [JsonPropertyName("teams")]
    public GameTeams? Teams { get; init; }

    [JsonPropertyName("scores")]
    public GameScores? Scores { get; init; }

    [JsonPropertyName("officials")]
    public string[]? Officials { get; init; }

    [JsonPropertyName("timesTied")]
    public int? TimesTied { get; init; }

    [JsonPropertyName("leadChanges")]
    public int? LeadChanges { get; init; }

    [JsonPropertyName("nugget")]
    public string? Nugget { get; init; }
}

public sealed class GameDate
{
    [JsonPropertyName("start")]
    public DateTimeOffset? Start { get; init; }

    [JsonPropertyName("end")]
    public DateTimeOffset? End { get; init; }

    [JsonPropertyName("duration")]
    public string? Duration { get; init; }
}

public sealed class GameStatus
{
    [JsonPropertyName("clock")]
    public string? Clock { get; init; }

    [JsonPropertyName("halftime")]
    public bool? Halftime { get; init; }

    [JsonPropertyName("short")]
    public int? Short { get; init; }

    [JsonPropertyName("long")]
    public string? Long { get; init; }
}

public sealed class GamePeriods
{
    [JsonPropertyName("current")]
    public int? Current { get; init; }

    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("endOfPeriod")]
    public bool? EndOfPeriod { get; init; }
}

public sealed class GameArena
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("state")]
    public string? State { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }
}

public sealed class GameTeams
{
    [JsonPropertyName("visitors")]
    public TeamRef? Visitors { get; init; }

    [JsonPropertyName("home")]
    public TeamRef? Home { get; init; }
}

public sealed class GameScores
{
    [JsonPropertyName("visitors")]
    public GameTeamScore? Visitors { get; init; }

    [JsonPropertyName("home")]
    public GameTeamScore? Home { get; init; }
}

public sealed class GameTeamScore
{
    [JsonPropertyName("win")]
    public int? Win { get; init; }

    [JsonPropertyName("loss")]
    public int? Loss { get; init; }

    [JsonPropertyName("series")]
    public GameSeriesScore? Series { get; init; }

    [JsonPropertyName("linescore")]
    public string[]? Linescore { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }
}

public sealed class GameSeriesScore
{
    [JsonPropertyName("win")]
    public int? Win { get; init; }

    [JsonPropertyName("loss")]
    public int? Loss { get; init; }
}

public sealed class GameRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}
