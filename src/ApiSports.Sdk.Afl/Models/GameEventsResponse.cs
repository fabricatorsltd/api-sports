using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class GameEventsResponse
{
    [JsonPropertyName("game")]
    public GameRef? GameRef { get; init; }

    [JsonPropertyName("events")]
    public GameEvent[]? Events { get; init; }
}

public sealed class GameEvent
{
    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("player")]
    public PlayerRef? Player { get; init; }

    [JsonPropertyName("period")]
    public int? Period { get; init; }

    [JsonPropertyName("minute")]
    public int? Minute { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
