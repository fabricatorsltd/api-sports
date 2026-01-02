using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class FixtureResponse
    {
        [JsonPropertyName("fixture")]
        public Fixture Fixture { get; set; }

        [JsonPropertyName("league")]
        public League League { get; set; }

        [JsonPropertyName("teams")]
        public HomeAway<Team?>? Teams { get; set; }

        [JsonPropertyName("goals")]
        public HomeAway<ushort?> Goals { get; set; }

        [JsonPropertyName("score")]
        public Score Score { get; set; }

        [JsonPropertyName("events")]
        public List<FixtureEvent> Events { get; set; }
        
        public string Test { get; set; }
    }
}
