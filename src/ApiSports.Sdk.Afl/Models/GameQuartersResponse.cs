using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Afl.Models;

public sealed class GameQuartersResponse
{
    [JsonPropertyName("game")]
    public GameRef? GameRef { get; init; }

    [JsonPropertyName("quarters")]
    public GameQuarter[]? Quarters { get; init; }
}

public sealed class GameQuarter
{
    [JsonPropertyName("quarter")]
    public int? Quarter { get; init; }

    [JsonPropertyName("teams")]
    public HomeAway<GameQuarterTeamScore>? Teams { get; init; }
}

public sealed class GameQuarterTeamScore
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("goals")]
    public int? Goals { get; init; }

    [JsonPropertyName("behinds")]
    public int? Behinds { get; init; }

    [JsonPropertyName("points")]
    public int? Points { get; init; }
}
