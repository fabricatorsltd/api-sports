using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerSubstitutes
    {
        [JsonProperty("in")]
        public ushort? In { get; set; }
        
        [JsonProperty("out")]
        public ushort? Out { get; set; }
        
        [JsonProperty("bench")]
        public ushort? Bench { get; set; }
    }
}