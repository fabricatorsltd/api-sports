using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Requests
    {
        [JsonProperty("current")]
        public uint Current { get; set; }
        
        [JsonProperty("limit_day")]
        public uint LimitDay { get; set; }
    }
}