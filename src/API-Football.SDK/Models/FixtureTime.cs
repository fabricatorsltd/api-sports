using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct FixtureTime
    {
        [JsonProperty("elapsed")]
        public ushort? Elapsed { get; set; }
        
        [JsonProperty("extra")]
        public ushort? Extra { get; set; }
    }
}