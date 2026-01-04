using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class RaceLaps
{
    [JsonPropertyName("current")]
    public int? Current { get; init; }

    [JsonPropertyName("total")]
    public int? Total { get; init; }
}