using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class ApiTeamResponse
    {
        [JsonProperty("team")]
        public Team Team { get; set; }
        
        [JsonProperty("venue")]
        public Venue Venue { get; set; }
    }
}
