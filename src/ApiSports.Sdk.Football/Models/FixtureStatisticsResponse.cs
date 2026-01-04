using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class FixtureStatisticsResponse
    {
        [JsonPropertyName("team")]
        public Team Team { get; set; }

        [JsonPropertyName("statistics")]
        public List<FixtureStatistic> Statistics { get; set; }
    }

    public sealed class FixtureStatistic
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public JsonElement? Value { get; set; }
    }
}
