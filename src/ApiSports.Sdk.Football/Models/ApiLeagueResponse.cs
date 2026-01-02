using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class ApiLeagueResponse
    {
        [JsonPropertyName("league")]
        public League League { get; set; }
        
        [JsonPropertyName("country")]
        public Country Country { get; set; }
        
        [JsonPropertyName("seasons")]
        public List<Season> Seasons { get; set; }
    }
}
