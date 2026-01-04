using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiTeamRankingResponse
{
    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("team")]
    public TeamSummary? Team { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }
}
