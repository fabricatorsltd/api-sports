using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Mma.Models;

public sealed class Fight
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("date")]
    public DateTimeOffset? Date { get; init; }

    [JsonPropertyName("time")]
    public string? Time { get; init; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("is_main")]
    public bool? IsMain { get; init; }

    [JsonPropertyName("category")]
    public string? Category { get; init; }

    [JsonPropertyName("status")]
    public FightStatus? Status { get; init; }

    [JsonPropertyName("fighters")]
    public FightFighters? Fighters { get; init; }
}

public sealed class FightStatus
{
    [JsonPropertyName("long")]
    public string? Long { get; init; }

    [JsonPropertyName("short")]
    public string? Short { get; init; }
}

public sealed class FightFighters
{
    [JsonPropertyName("first")]
    public FightFighter? First { get; init; }

    [JsonPropertyName("second")]
    public FightFighter? Second { get; init; }
}

public sealed class FightFighter
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    [JsonPropertyName("winner")]
    public bool? Winner { get; init; }
}

public sealed class FightRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}

public sealed class FighterRef
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}
