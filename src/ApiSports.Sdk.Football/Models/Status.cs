using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Status
    {
        [JsonPropertyName("account")]
        public Account Account { get; set; }
        
        [JsonPropertyName("subscription")]
        public Subscription Subscription { get; set; }
        
        [JsonPropertyName("requests")]
        public Requests Requests { get; set; }
    }
}
