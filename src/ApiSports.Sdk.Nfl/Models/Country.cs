using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class Country
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("flag")]
    public string? Flag { get; init; }
}
