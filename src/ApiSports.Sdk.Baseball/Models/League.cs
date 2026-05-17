using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Baseball.Models;

public sealed class League
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }

    [JsonPropertyName("seasons")]
    public LeagueSeason[]? Seasons { get; init; }
}

public sealed class LeagueSeason
{
    [JsonPropertyName("season")]
    public int? Season { get; init; }

    [JsonPropertyName("current")]
    public bool? Current { get; init; }

    [JsonPropertyName("start")]
    public string? Start { get; init; }

    [JsonPropertyName("end")]
    public string? End { get; init; }
}

public sealed class LeagueRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }
}
