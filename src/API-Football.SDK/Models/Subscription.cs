using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Subscription
    {
        [JsonProperty("plan")]
        public string Plan { get; set; }
        
        [JsonProperty("end")]
        public string End { get; set; } // 2020-04-10T23:24:27+00:00
        
        [JsonProperty("active")]
        public string Active { get; set; }
    }
}