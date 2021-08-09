using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerCards
    {
        [JsonProperty("yellow")]
        public ushort? Yellow { get; set;  }
        
        [JsonProperty("yellowred")]
        public ushort? Yellowred { get; set; }
        
        [JsonProperty("red")]
        public ushort? Red { get; set; }
    }
}