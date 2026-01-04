using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class PlayerProfileResponse
    {
        [JsonPropertyName("player")]
        public PlayerProfile Player { get; set; }
    }
}
