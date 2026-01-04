using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class OddsBetResponse
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
