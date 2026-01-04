using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class TrophyResponse
    {
        [JsonPropertyName("league")]
        public string? League { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("season")]
        public string? Season { get; set; }

        [JsonPropertyName("place")]
        public string? Place { get; set; }
    }
}
