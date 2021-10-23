using System;
using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Standing
    {
        [JsonProperty("rank")]
        public ushort Rank { get; set; }
        
        [JsonProperty("team")]
        public Team Team { get; set; }
        
        [JsonProperty("points")]
        public ushort Points { get; set; }
        
        [JsonProperty("goalsDiff")]
        public short GoalsDiff { get; set; }
        
        [JsonProperty("group")]
        public string Group { get; set; }
        
        [JsonProperty("form")]
        public string Form { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("all")]
        public StandingStatistics All { get; set; }
        
        [JsonProperty("home")]
        public StandingStatistics Home { get; set; }
        
        [JsonProperty("away")]
        public StandingStatistics Away { get; set; }

        [JsonProperty("update")]
        public DateTime Update { get; set; }
    }
}