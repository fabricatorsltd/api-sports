using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Nfl.Models;

public sealed class Team
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("coach")]
    public string? Coach { get; init; }

    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    [JsonPropertyName("stadium")]
    public string? Stadium { get; init; }

    [JsonPropertyName("established")]
    public int? Established { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }
}

public sealed class TeamRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }
}
