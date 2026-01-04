using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class PlayerTeamResponse
    {
        [JsonPropertyName("team")]
        public Team Team { get; set; }

        [JsonPropertyName("seasons")]
        public int[] Seasons { get; set; }
    }
}
