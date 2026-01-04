using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerDribbles
    {
        [JsonPropertyName("attempts")]
        public ushort? Attempts { get; set;  }
        
        [JsonPropertyName("success")]
        public ushort? Success { get; set; }
        
        [JsonPropertyName("past")]
        public ushort? Past { get; set; }
    }
}
