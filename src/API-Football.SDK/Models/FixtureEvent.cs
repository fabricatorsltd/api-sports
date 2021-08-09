using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class FixtureEvent
    {
        [JsonProperty("time")]
        public FixtureTime Time { get; set; }
        
        [JsonProperty("team")]
        public Team Team { get; set; }
        
        [JsonProperty("player")]
        public Player Player { get; set; }
        
        [JsonProperty("assist")]
        public Player Assist { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("detail")]
        public string Detail { get; set; }
        
        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
