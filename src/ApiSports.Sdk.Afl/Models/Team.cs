using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class Team
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }
}

public sealed class TeamRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}
