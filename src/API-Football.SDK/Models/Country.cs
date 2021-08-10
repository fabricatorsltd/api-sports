using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}