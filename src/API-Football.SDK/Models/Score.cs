using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Score
    {
        [JsonProperty("halftime")]
        public HomeAway<ushort?>  Halftime { get; set; }
        
        [JsonProperty("fulltime")]
        public HomeAway<ushort?>  Fulltime { get; set; }
        
        [JsonProperty("extratime")]
        public HomeAway<ushort?>  Extratime { get; set; }
        
        [JsonProperty("penalty")]
        public HomeAway<ushort?>  Penalty { get; set; }
    }
}
