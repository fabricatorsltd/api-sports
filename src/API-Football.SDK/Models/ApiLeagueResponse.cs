using System.Collections.Generic;
using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class ApiLeagueResponse
    {
        [JsonProperty("league")]
        public League League { get; set; }
        
        [JsonProperty("country")]
        public Country Country { get; set; }
        
        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }
    }
}
