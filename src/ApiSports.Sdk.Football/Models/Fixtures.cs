using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Fixtures
    {
        [JsonPropertyName("events")]
        public bool Events { get; set; }
        
        [JsonPropertyName("lineups")]
        public bool Lineups { get; set; }
        
        [JsonPropertyName("statistics_fixtures")]
        public bool StatisticsFixtures { get; set; }
        
        [JsonPropertyName("statistics_players")]
        public bool StatisticsPlayers { get; set; }
    }
}
