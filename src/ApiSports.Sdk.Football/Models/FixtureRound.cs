using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class FixtureRound
    {
        [JsonPropertyName("round")]
        public string Round { get; set; }

        [JsonPropertyName("dates")]
        public DateOnly[] Dates { get; set; }
    }
}
