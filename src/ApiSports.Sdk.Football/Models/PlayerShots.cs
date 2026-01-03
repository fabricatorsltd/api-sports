using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerShots
    {
        [JsonPropertyName("total")]
        public ushort? Total { get; set;  }
        
        [JsonPropertyName("on")]
        public ushort? On { get; set; }
    }
}
