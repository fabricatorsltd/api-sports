using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Afl.Models;

public sealed class Standing
{
    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("team")]
    public Team? Team { get; init; }

    [JsonPropertyName("pts")]
    public int? Points { get; init; }

    [JsonPropertyName("games")]
    public StandingGames? Games { get; init; }

    [JsonPropertyName("points")]
    public StandingPoints? PointsFor { get; init; }

    [JsonPropertyName("last_5")]
    public string? Last5 { get; init; }
}

public sealed class StandingGames
{
    [JsonPropertyName("played")]
    public int? Played { get; init; }

    [JsonPropertyName("win")]
    public int? Win { get; init; }

    [JsonPropertyName("drawn")]
    public int? Drawn { get; init; }

    [JsonPropertyName("lost")]
    public int? Lost { get; init; }
}

public sealed class StandingPoints
{
    [JsonPropertyName("for")]
    public int? For { get; init; }

    [JsonPropertyName("against")]
    public int? Against { get; init; }
}
