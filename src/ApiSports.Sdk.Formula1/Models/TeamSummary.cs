using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class TeamSummary
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }
}