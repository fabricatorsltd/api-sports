using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class DriverTeamSeason
{
    [JsonPropertyName("season")]
    public int? Season { get; init; }

    [JsonPropertyName("team")]
    public TeamSummary? Team { get; init; }
}