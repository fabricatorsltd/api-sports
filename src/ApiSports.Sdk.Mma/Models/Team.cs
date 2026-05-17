using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Mma.Models;

public sealed class Team
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
