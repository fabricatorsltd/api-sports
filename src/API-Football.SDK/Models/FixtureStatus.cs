using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class FixtureStatus
    {
        [JsonProperty("long")]
        public string Long { get; set; }
        
        [JsonProperty("short")]
        public string Short { get; set; }
        
        [JsonProperty("elapsed")]
        public ushort Elapsed { get; set; }
    }
}
