using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class League : LeagueBase
    {
        [JsonPropertyName("standings")]
        public bool Standings { get; set; }
        
        [JsonPropertyName("seasons")]
        public Season[] Seasons { get; set; }
    }
}
