using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Subscription
    {
        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("end")]
        public string End { get; set; } // 2020-04-10T23:24:27+00:00

        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}
