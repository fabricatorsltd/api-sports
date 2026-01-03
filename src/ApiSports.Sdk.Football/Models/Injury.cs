using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Injury
    {
        [JsonPropertyName("player")]
        public Player Player { get; set; }
        
        [JsonPropertyName("team")]
        public Team Team { get; set; }
        
        [JsonPropertyName("fixture")]
        public Fixture Fixture { get; set; }
        
        [JsonPropertyName("league")]
        public League League { get; set; }
    }
}
