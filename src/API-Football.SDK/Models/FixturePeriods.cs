using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct FixturePeriods
    {
        [JsonProperty("first")]
        public uint? First { get; set; }
        
        [JsonProperty("second")]
        public uint? Second { get; set; }
    }
}