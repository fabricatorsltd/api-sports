using System.Collections.Generic;
using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class League
    {
        [JsonProperty("id")]
        public ushort Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("logo")]
        public string Logo { get; set; }
        
        [JsonProperty("flag")]
        public string Flag { get; set; }
        
        [JsonProperty("season")]
        public ushort Season { get; set; }
        
        [JsonProperty("round")]
        public string Round { get; set; }
        
        [JsonProperty("standings")]
        public List<List<Standing>> Standings { get; set; }
    }
}