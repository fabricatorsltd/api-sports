using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Fixtures
    {
        [JsonProperty("events")]
        public bool Events { get; set; }
        
        [JsonProperty("lineups")]
        public bool Lineups { get; set; }
        
        [JsonProperty("statistics_fixtures")]
        public bool StatisticsFixtures { get; set; }
        
        [JsonProperty("statistics_players")]
        public bool StatisticsPlayers { get; set; }
    }
}