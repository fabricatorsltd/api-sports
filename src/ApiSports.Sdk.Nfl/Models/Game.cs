using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class Game
{
    [JsonPropertyName("game")]
    public GameInfo? GameInfo { get; init; }

    [JsonPropertyName("league")]
    public LeagueRef? League { get; init; }

    [JsonPropertyName("teams")]
    public HomeAway<TeamRef>? Teams { get; init; }

    [JsonPropertyName("scores")]
    public HomeAway<GameScore>? Scores { get; init; }
}

public sealed class GameInfo
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("stage")]
    public string? Stage { get; init; }

    [JsonPropertyName("week")]
    public string? Week { get; init; }

    [JsonPropertyName("date")]
    public GameDate? Date { get; init; }

    [JsonPropertyName("venue")]
    public GameVenue? Venue { get; init; }

    [JsonPropertyName("status")]
    public GameStatus? Status { get; init; }
}

public sealed class GameDate
{
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("date")]
    public string? Date { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }
}

public sealed class GameVenue
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }
}

public sealed class GameStatus
{
    [JsonPropertyName("short")]
    public string? Short { get; init; }

    [JsonPropertyName("long")]
    public string? Long { get; init; }

    [JsonPropertyName("timer")]
    public string? Timer { get; init; }
}

public sealed class GameScore
{
    [JsonPropertyName("quarter_1")]
    public int? Quarter1 { get; init; }

    [JsonPropertyName("quarter_2")]
    public int? Quarter2 { get; init; }

    [JsonPropertyName("quarter_3")]
    public int? Quarter3 { get; init; }

    [JsonPropertyName("quarter_4")]
    public int? Quarter4 { get; init; }

    [JsonPropertyName("overtime")]
    public int? Overtime { get; init; }

    [JsonPropertyName("total")]
    public int? Total { get; init; }
}

public sealed class GameRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}

public sealed class GameEvent
{
    [JsonPropertyName("quarter")]
    public string? Quarter { get; init; }

    [JsonPropertyName("minute")]
    public string? Minute { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("player")]
    public PlayerSummary? Player { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("comment")]
    public string? Comment { get; init; }

    [JsonPropertyName("score")]
    public HomeAway<int?>? Score { get; init; }
}
