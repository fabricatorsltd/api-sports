using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Volleyball.Models;

public sealed class Country
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("flag")]
    public string? Flag { get; init; }
}
