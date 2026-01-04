using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class ApiStandingsResponse
    {
        [JsonPropertyName("league")]
        public LeagueWithStandings League { get; set; }
    }
}
