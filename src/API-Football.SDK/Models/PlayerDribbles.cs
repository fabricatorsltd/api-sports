using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerDribbles
    {
        [JsonProperty("attempts")]
        public ushort? Attempts { get; set;  }
        
        [JsonProperty("success")]
        public ushort? Success { get; set; }
        
        [JsonProperty("past")]
        public ushort? Past { get; set; }
    }
}