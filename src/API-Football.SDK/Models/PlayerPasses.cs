using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerPasses
    {
        [JsonProperty("total")]
        public ushort? Total { get; set;  }
        
        [JsonProperty("key")]
        public ushort? Key { get; set; }
        
        [JsonProperty("accuracy")]
        public ushort? Accuracy { get; set; }
    }
}