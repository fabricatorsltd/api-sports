using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Team
    {
        [JsonProperty("id")]
        public uint? Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("founded")]
        public ushort Founded { get; set; }
        
        [JsonProperty("national")]
        public bool National { get; set; }
        
        [JsonProperty("logo")]
        public string Logo { get; set; }
        
        [JsonProperty("winner")]
        public bool? Winner { get; set; }
    }
}