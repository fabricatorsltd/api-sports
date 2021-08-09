using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerGoals
    {
        [JsonProperty("total")]
        public ushort? Total { get; set;  }
        
        [JsonProperty("conceded")]
        public ushort? Conceded { get; set; }
        
        [JsonProperty("assists")]
        public ushort? Assists { get; set; }
        
        [JsonProperty("saves")]
        public ushort? Saves { get; set; }
    }
}