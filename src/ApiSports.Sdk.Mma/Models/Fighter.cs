using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Mma.Models;

public sealed class Fighter
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("photo")]
    public string? Photo { get; init; }

    [JsonPropertyName("gender")]
    public string? Gender { get; init; }

    [JsonPropertyName("birth_date")]
    public string? BirthDate { get; init; }

    [JsonPropertyName("age")]
    public int? Age { get; init; }

    [JsonPropertyName("height")]
    public string? Height { get; init; }

    [JsonPropertyName("weight")]
    public string? Weight { get; init; }

    [JsonPropertyName("reach")]
    public string? Reach { get; init; }

    [JsonPropertyName("stance")]
    public string? Stance { get; init; }

    [JsonPropertyName("category")]
    public string? Category { get; init; }

    [JsonPropertyName("team")]
    public Team? Team { get; init; }

    [JsonPropertyName("last_update")]
    public DateTimeOffset? LastUpdate { get; init; }
}
