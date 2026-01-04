using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Team
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("country")]
        public string Country { get; set; }
        
        [JsonPropertyName("founded")]
        public ushort? Founded { get; set; }
        
        [JsonPropertyName("national")]
        public bool National { get; set; }
        
        [JsonPropertyName("logo")]
        public string Logo { get; set; }
        
        [JsonPropertyName("winner")]
        public bool? Winner { get; set; }
    }
}
