using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Venue
    {
        [JsonProperty("id")]
        public uint? Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("address")]
        public string Address { get; set; }
        
        [JsonProperty("city")]
        public string City { get; set; }
        
        [JsonProperty("capacity")]
        public uint? Capacity { get; set; }
        
        [JsonProperty("surface")]
        public string Surface { get; set; }
        
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}