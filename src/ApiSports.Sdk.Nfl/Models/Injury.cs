using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class Injury
{
    [JsonPropertyName("player")]
    public PlayerSummary? Player { get; init; }

    [JsonPropertyName("team")]
    public TeamRef? Team { get; init; }

    [JsonPropertyName("date")]
    public string? Date { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
