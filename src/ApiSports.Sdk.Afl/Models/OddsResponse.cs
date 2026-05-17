using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class OddsResponse
{
    [JsonPropertyName("league")]
    public GameLeague? League { get; init; }

    [JsonPropertyName("game")]
    public GameRef? Game { get; init; }

    [JsonPropertyName("update")]
    public DateTimeOffset? Update { get; init; }

    [JsonPropertyName("bookmakers")]
    public OddsBookmaker[]? Bookmakers { get; init; }
}

public sealed class OddsBookmaker
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("bets")]
    public OddsBet[]? Bets { get; init; }
}

public sealed class OddsBet
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("values")]
    public OddsBetValue[]? Values { get; init; }
}

public sealed class OddsBetValue
{
    [JsonPropertyName("value")]
    public string? Value { get; init; }

    [JsonPropertyName("odd")]
    public string? Odd { get; init; }
}

public sealed class BetDefinition
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public sealed class BookmakerDefinition
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
