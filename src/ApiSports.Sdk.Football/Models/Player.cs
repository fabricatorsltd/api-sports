using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Player
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("photo")]
        public string Photo { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
