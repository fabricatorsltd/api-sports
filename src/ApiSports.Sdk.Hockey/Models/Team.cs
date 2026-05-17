using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Hockey.Models;

public sealed class Team
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("founded")]
    public int? Founded { get; init; }

    [JsonPropertyName("national")]
    public bool? National { get; init; }

    [JsonPropertyName("colors")]
    public string[]? Colors { get; init; }

    [JsonPropertyName("arena")]
    public TeamArena? Arena { get; init; }

    [JsonPropertyName("country")]
    public Country? Country { get; init; }
}

public sealed class TeamArena
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("capacity")]
    public int? Capacity { get; init; }

    [JsonPropertyName("location")]
    public string? Location { get; init; }
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
