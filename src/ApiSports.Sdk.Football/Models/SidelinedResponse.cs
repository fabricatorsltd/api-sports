using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class SidelinedResponse
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("start")]
        public DateTime? Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime? End { get; set; }
    }
}
