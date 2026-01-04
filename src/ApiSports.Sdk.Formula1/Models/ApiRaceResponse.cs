using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Formula1.Models;

public sealed class ApiRaceResponse
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("competition")]
    public CompetitionSummary? Competition { get; init; }

    [JsonPropertyName("circuit")]
    public CircuitSummary? Circuit { get; init; }

    [JsonPropertyName("season")]
    public int? Season { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("laps")]
    public RaceLaps? Laps { get; init; }

    [JsonPropertyName("fastest_lap")]
    public RaceFastestLap? FastestLap { get; init; }

    [JsonPropertyName("distance")]
    public string? Distance { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("date")]
    public string? Date { get; init; }

    [JsonPropertyName("weather")]
    public string? Weather { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }
}
