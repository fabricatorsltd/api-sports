using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiDriverRankingResponse
{
    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("driver")]
    public DriverSummary? Driver { get; init; }

    [JsonPropertyName("team")]
    public TeamSummary? Team { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }

    [JsonPropertyName("wins")]
    public int? Wins { get; init; }

    [JsonPropertyName("behind")]
    public int? Behind { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }
}