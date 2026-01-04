using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerDuels
    {
        [JsonPropertyName("total")]
        public ushort? Total { get; set;  }
        
        [JsonPropertyName("won")]
        public ushort? Won { get; set; }
    }
}
