using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Handball.Models;

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

    [JsonPropertyName("week")]
    public string? Week { get; init; }

    [JsonPropertyName("status")]
    public GameStatus? Status { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }

    [JsonPropertyName("league")]
    public LeagueRef? League { get; init; }

    [JsonPropertyName("teams")]
    public HomeAway<TeamRef>? Teams { get; init; }

    [JsonPropertyName("scores")]
    public HomeAway<int?>? Scores { get; init; }

    [JsonPropertyName("periods")]
    public GamePeriods? Periods { get; init; }
}

public sealed class GameStatus
{
    [JsonPropertyName("long")]
    public string? Long { get; init; }

    [JsonPropertyName("short")]
    public string? Short { get; init; }
}

public sealed class GamePeriods
{
    [JsonPropertyName("first")]
    public HomeAway<int?>? First { get; init; }

    [JsonPropertyName("second")]
    public HomeAway<int?>? Second { get; init; }
}

public sealed class GameRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}
