using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class CoachCareer
    {
        [JsonPropertyName("team")]
        public Team Team { get; set; }

        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime? End { get; set; }
    }
}
