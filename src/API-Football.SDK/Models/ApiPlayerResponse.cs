using System.Collections.Generic;
using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class ApiPlayerResponse
    {
        [JsonProperty("player")]
        public Player Player { get; set; }
        
        [JsonProperty("statistics")]
        public List<PlayerStatistics> Statistics { get; set; }
    }
}