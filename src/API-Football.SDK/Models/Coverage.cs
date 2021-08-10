using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Coverage
    {
        [JsonProperty("fixtures")]
        public Fixtures Fixtures { get; set; }
        
        [JsonProperty("standings")]
        public bool Standings { get; set; }
        
        [JsonProperty("players")]
        public bool Players { get; set; }
        
        [JsonProperty("top_scorers")]
        public bool TopScores { get; set; }
        
        [JsonProperty("top_assists")]
        public bool TopAssists { get; set; }
        
        [JsonProperty("top_cards")]
        public bool TopCards { get; set; }
        
        [JsonProperty("injuries")]
        public bool Injuries { get; set; }
        
        [JsonProperty("predictions")]
        public bool Predictions { get; set; }
        
        [JsonProperty("odds")]
        public bool Odds { get; set; }
    }
}