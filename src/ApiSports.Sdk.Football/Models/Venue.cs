using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Venue
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        
        [JsonPropertyName("city")]
        public string? City { get; set; }
        
        [JsonPropertyName("capacity")]
        public uint? Capacity { get; set; }
        
        [JsonPropertyName("surface")]
        public string? Surface { get; set; }
        
        [JsonPropertyName("image")]
        public string? Image { get; set; }
    }
}
