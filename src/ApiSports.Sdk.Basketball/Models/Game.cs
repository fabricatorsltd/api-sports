using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Basketball.Models;

public sealed class Game
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("date")]
    public DateTimeOffset? Date { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("stage")]
    public string? Stage { get; init; }

    [JsonPropertyName("week")]
    public string? Week { get; init; }

    [JsonPropertyName("venue")]
    public string? Venue { get; init; }

    [JsonPropertyName("status")]
    public GameStatus? Status { get; init; }

    [JsonPropertyName("league")]
    public LeagueRef? League { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }

    [JsonPropertyName("teams")]
    public HomeAway<TeamRef>? Teams { get; init; }

    [JsonPropertyName("scores")]
    public HomeAway<GameScore>? Scores { get; init; }
}

public sealed class GameStatus
{
    [JsonPropertyName("long")]
    public string? Long { get; init; }

    [JsonPropertyName("short")]
    public string? Short { get; init; }

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

    [JsonPropertyName("over_time")]
    public int? OverTime { get; init; }

    [JsonPropertyName("total")]
    public int? Total { get; init; }
}

public sealed class GameRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}
