using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerPenalty
    {
        [JsonProperty("won")]
        public ushort? Won { get; set;  }
        
        [JsonProperty("committed")]
        public ushort? Committed { get; set; }
        
        [JsonProperty("scored")]
        public ushort? Scored { get; set; }
        
        [JsonProperty("missed")]
        public ushort? Missed { get; set; }
        
        [JsonProperty("saved")]
        public ushort? Saved { get; set; }
    }
}