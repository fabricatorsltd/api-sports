using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class StandingStatistics
    {
        [JsonPropertyName("played")]
        public ushort Played { get; set; }
        
        [JsonPropertyName("win")]
        public ushort Win { get; set; }
        
        [JsonPropertyName("draw")]
        public ushort Draw { get; set; }
        
        [JsonPropertyName("lose")]
        public ushort Lose { get; set; }
        
        [JsonPropertyName("goals")]
        public StandingGoals Goals { get; set; }
    }
}
