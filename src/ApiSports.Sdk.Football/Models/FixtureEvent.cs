using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class FixtureEvent
    {
        [JsonPropertyName("time")]
        public FixtureTime Time { get; set; }
        
        [JsonPropertyName("team")]
        public Team Team { get; set; }
        
        [JsonPropertyName("player")]
        public Player Player { get; set; }
        
        [JsonPropertyName("assist")]
        public Player Assist { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("detail")]
        public string Detail { get; set; }
        
        [JsonPropertyName("comments")]
        public string Comments { get; set; }
    }
}
