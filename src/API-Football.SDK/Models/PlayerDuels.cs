using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerDuels
    {
        [JsonProperty("total")]
        public ushort? Total { get; set;  }
        
        [JsonProperty("won")]
        public ushort? Won { get; set; }
    }
}