using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class HighestRaceFinish
{
    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("number")]
    public int? Number { get; init; }
}