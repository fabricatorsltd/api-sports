using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class LeagueBase
    {
        [JsonPropertyName("id")]
        public ushort Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("country")]
        public string Country { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("logo")]
        public string Logo { get; set; }
        
        [JsonPropertyName("flag")]
        public string Flag { get; set; }
        
        [JsonPropertyName("season")]
        public ushort Season { get; set; }
        
        [JsonPropertyName("round")]
        public string Round { get; set; }
    }
}
