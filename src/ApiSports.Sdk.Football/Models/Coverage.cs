using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Coverage
    {
        [JsonPropertyName("fixtures")]
        public Fixtures Fixtures { get; set; }
        
        [JsonPropertyName("standings")]
        public bool Standings { get; set; }
        
        [JsonPropertyName("players")]
        public bool Players { get; set; }
        
        [JsonPropertyName("top_scorers")]
        public bool TopScores { get; set; }
        
        [JsonPropertyName("top_assists")]
        public bool TopAssists { get; set; }
        
        [JsonPropertyName("top_cards")]
        public bool TopCards { get; set; }
        
        [JsonPropertyName("injuries")]
        public bool Injuries { get; set; }
        
        [JsonPropertyName("predictions")]
        public bool Predictions { get; set; }
        
        [JsonPropertyName("odds")]
        public bool Odds { get; set; }
    }
}
