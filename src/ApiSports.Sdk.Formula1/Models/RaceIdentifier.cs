using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class RaceIdentifier
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
}