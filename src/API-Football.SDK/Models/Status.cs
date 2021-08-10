using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Status
    {
        [JsonProperty("account")]
        public Account Account { get; set; }
        
        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
        
        [JsonProperty("requests")]
        public Requests Requests { get; set; }
    }
}