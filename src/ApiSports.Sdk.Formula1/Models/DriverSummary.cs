using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class DriverSummary
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("abbr")]
    public string? Abbr { get; init; }

    [JsonPropertyName("number")]
    public int? Number { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }
}