using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class CircuitSummary
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }
}