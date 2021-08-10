using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Player
    {
        [JsonProperty("id")]
        public uint? Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("photo")]
        public string Photo { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}