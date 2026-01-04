using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class LeagueWithStandings : LeagueBase
    {
        [JsonPropertyName("standings")]
        public Standing[][] Standings { get; set; }
    }
}
