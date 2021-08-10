using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Injury
    {
        [JsonProperty("player")]
        public Player Player { get; set; }
        
        [JsonProperty("team")]
        public Team Team { get; set; }
        
        [JsonProperty("fixture")]
        public Fixture Fixture { get; set; }
        
        [JsonProperty("league")]
        public League League { get; set; }
    }
}