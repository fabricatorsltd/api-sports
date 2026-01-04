using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class CompetitionSummary
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("location")]
    public CompetitionLocation? Location { get; init; }
}