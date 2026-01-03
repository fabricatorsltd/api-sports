using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Standing
    {
        [JsonPropertyName("rank")]
        public ushort Rank { get; set; }
        
        [JsonPropertyName("team")]
        public Team Team { get; set; }
        
        [JsonPropertyName("points")]
        public ushort Points { get; set; }
        
        [JsonPropertyName("goalsDiff")]
        public short GoalsDiff { get; set; }
        
        [JsonPropertyName("group")]
        public string Group { get; set; }
        
        [JsonPropertyName("form")]
        public string Form { get; set; }
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("all")]
        public StandingStatistics All { get; set; }
        
        [JsonPropertyName("home")]
        public StandingStatistics Home { get; set; }
        
        [JsonPropertyName("away")]
        public StandingStatistics Away { get; set; }

        [JsonPropertyName("update")]
        public DateTime Update { get; set; }
    }
}
