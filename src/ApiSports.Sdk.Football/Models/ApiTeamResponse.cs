using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class ApiTeamResponse
    {
        [JsonPropertyName("team")]
        public Team Team { get; set; }
        
        [JsonPropertyName("venue")]
        public Venue Venue { get; set; }
    }
}
