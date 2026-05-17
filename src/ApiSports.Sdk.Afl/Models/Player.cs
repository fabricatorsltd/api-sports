using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class Player
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class PlayerRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}
