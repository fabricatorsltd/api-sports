using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Birth
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("place")]
        public string Place { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
