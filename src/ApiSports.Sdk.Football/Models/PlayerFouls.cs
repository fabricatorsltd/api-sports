using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerFouls
    {
        [JsonPropertyName("drawn")]
        public ushort? Drawn { get; set;  }
        
        [JsonPropertyName("committed")]
        public ushort? Committed { get; set; }
    }
}
