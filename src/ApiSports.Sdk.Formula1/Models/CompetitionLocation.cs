using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class CompetitionLocation
{
    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }
}