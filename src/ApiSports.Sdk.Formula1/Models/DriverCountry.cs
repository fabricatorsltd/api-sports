using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class DriverCountry
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }
}