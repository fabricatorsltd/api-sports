using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class FixtureStatus
    {
        [JsonPropertyName("long")]
        public string? Long { get; set; }
        
        [JsonPropertyName("short")]
        public string? Short { get; set; }
        
        [JsonPropertyName("elapsed")]
        public ushort? Elapsed { get; set; }
    }
}
