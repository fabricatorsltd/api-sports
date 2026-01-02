using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class ApiPlayerResponse
    {
        [JsonPropertyName("player")]
        public Player Player { get; set; }
        
        [JsonPropertyName("statistics")]
        public List<PlayerStatistics> Statistics { get; set; }
    }
}
