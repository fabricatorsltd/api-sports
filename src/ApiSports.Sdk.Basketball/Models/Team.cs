using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Basketball.Models;

public sealed class Team
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("nationnal")]
    public bool? National { get; init; }

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
