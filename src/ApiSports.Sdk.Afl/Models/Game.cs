using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Afl.Models;

public sealed class Game
{
    [JsonPropertyName("game")]
    public GameRef? GameRef { get; init; }

    [JsonPropertyName("league")]
    public GameLeague? League { get; init; }

    [JsonPropertyName("date")]
    public DateTimeOffset? Date { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("timestamp")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Timestamp { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("round")]
    public string? Round { get; init; }

    [JsonPropertyName("week")]
    public int? Week { get; init; }

    [JsonPropertyName("venue")]
    public string? Venue { get; init; }

    [JsonPropertyName("attendance")]
    public int? Attendance { get; init; }

    [JsonPropertyName("status")]
    public GameStatus? Status { get; init; }

    [JsonPropertyName("teams")]
    public HomeAway<Team>? Teams { get; init; }

    [JsonPropertyName("scores")]
    public HomeAway<GameScore>? Scores { get; init; }
}

public sealed class GameRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}

public sealed class GameLeague
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }
}

public sealed class GameStatus
{
    [JsonPropertyName("long")]
    public string? Long { get; init; }

    [JsonPropertyName("short")]
    public string? Short { get; init; }
}

public sealed class GameScore
{
    [JsonPropertyName("score")]
    public int? Score { get; init; }

    [JsonPropertyName("goals")]
    public int? Goals { get; init; }

    [JsonPropertyName("behinds")]
    public int? Behinds { get; init; }

    [JsonPropertyName("psgoals")]
    public int? PenaltyShootoutGoals { get; init; }

    [JsonPropertyName("psbehinds")]
    public int? PenaltyShootoutBehinds { get; init; }
}
