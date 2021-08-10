using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class StandingStatistics
    {
        [JsonProperty("played")]
        public ushort Played { get; set; }
        
        [JsonProperty("win")]
        public ushort Win { get; set; }
        
        [JsonProperty("draw")]
        public ushort Draw { get; set; }
        
        [JsonProperty("lose")]
        public ushort Lose { get; set; }
        
        [JsonProperty("goals")]
        public StandingGoals Goals { get; set; }
    }
}
