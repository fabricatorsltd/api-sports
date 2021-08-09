using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerTackles
    {
        [JsonProperty("total")]
        public ushort? Total { get; set;  }
        
        [JsonProperty("blocks")]
        public ushort? Blocks { get; set; }
        
        [JsonProperty("interceptions")]
        public ushort? Interceptions { get; set; }
    }
}