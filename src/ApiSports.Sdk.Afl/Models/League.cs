using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class League
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }

    [JsonPropertyName("start")]
    public string? Start { get; init; }

    [JsonPropertyName("end")]
    public string? End { get; init; }

    [JsonPropertyName("current")]
    public bool? Current { get; init; }
}
