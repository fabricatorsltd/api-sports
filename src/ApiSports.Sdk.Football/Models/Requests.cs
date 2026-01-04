using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Requests
    {
        [JsonPropertyName("current")]
        public uint Current { get; set; }
        
        [JsonPropertyName("limit_day")]
        public uint LimitDay { get; set; }
    }
}
