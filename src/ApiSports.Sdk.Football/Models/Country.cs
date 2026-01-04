using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Country
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("code")]
        public string? Code { get; set; }
        
        [JsonPropertyName("flag")]
        public string? Flag { get; set; }
    }
}
