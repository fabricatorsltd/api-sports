using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class OddsBookmakerResponse
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
