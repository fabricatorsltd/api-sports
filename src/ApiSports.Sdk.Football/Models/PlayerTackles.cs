using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerTackles
    {
        [JsonPropertyName("total")]
        public ushort? Total { get; set;  }
        
        [JsonPropertyName("blocks")]
        public ushort? Blocks { get; set; }
        
        [JsonPropertyName("interceptions")]
        public ushort? Interceptions { get; set; }
    }
}
