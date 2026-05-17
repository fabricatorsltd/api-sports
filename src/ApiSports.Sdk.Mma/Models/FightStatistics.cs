using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Mma.Models;

public sealed class FightStatistics
{
    [JsonPropertyName("fight")]
    public FightRef? Fight { get; init; }

    [JsonPropertyName("fighter")]
    public FighterRef? Fighter { get; init; }

    [JsonPropertyName("strikes")]
    public FightStrikes? Strikes { get; init; }
}

public sealed class FightStrikes
{
    [JsonPropertyName("total")]
    public FightStrikeZones? Total { get; init; }

    [JsonPropertyName("power")]
    public FightStrikeZones? Power { get; init; }

    [JsonPropertyName("takedowns")]
    public FightTakedowns? Takedowns { get; init; }

    [JsonPropertyName("submissions")]
    public int? Submissions { get; init; }

    [JsonPropertyName("control_time")]
    public string? ControlTime { get; init; }

    [JsonPropertyName("knockdowns")]
    public int? Knockdowns { get; init; }
}

public sealed class FightStrikeZones
{
    [JsonPropertyName("head")]
    public int? Head { get; init; }

    [JsonPropertyName("body")]
    public int? Body { get; init; }

    [JsonPropertyName("legs")]
    public int? Legs { get; init; }
}

public sealed class FightTakedowns
{
    [JsonPropertyName("attempt")]
    public int? Attempt { get; init; }

    [JsonPropertyName("landed")]
    public int? Landed { get; init; }
}
