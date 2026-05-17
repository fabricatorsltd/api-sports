using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Hockey.Models;

public sealed class GameEvent
{
    [JsonPropertyName("game_id")]
    public int? GameId { get; init; }

    [JsonPropertyName("period")]
    public string? Period { get; init; }

    [JsonPropertyName("minute")]
    public string? Minute { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("players")]
    public string[]? Players { get; init; }

    [JsonPropertyName("assists")]
    public string[]? Assists { get; init; }

    [JsonPropertyName("comment")]
    public string? Comment { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
