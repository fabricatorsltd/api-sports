using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerFouls
    {
        [JsonProperty("drawn")]
        public ushort? Drawn { get; set;  }
        
        [JsonProperty("committed")]
        public ushort? Committed { get; set; }
    }
}