using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerShots
    {
        [JsonProperty("total")]
        public ushort? Total { get; set;  }
        
        [JsonProperty("on")]
        public ushort? On { get; set; }
    }
}