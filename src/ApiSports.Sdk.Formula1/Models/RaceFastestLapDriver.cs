using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class RaceFastestLapDriver
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}