using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Mma.Models;

public sealed class FightResult
{
    [JsonPropertyName("fight")]
    public FightRef? Fight { get; init; }

    [JsonPropertyName("won_type")]
    public string? WonType { get; init; }

    [JsonPropertyName("round")]
    public int? Round { get; init; }

    [JsonPropertyName("minute")]
    public string? Minute { get; init; }

    [JsonPropertyName("ko_type")]
    public string? KoType { get; init; }

    [JsonPropertyName("target")]
    public string? Target { get; init; }

    [JsonPropertyName("sub_type")]
    public string? SubType { get; init; }

    [JsonPropertyName("score")]
    public string[]? Score { get; init; }
}
