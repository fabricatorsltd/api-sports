using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerCards
    {
        [JsonPropertyName("yellow")]
        public ushort? Yellow { get; set;  }
        
        [JsonPropertyName("yellowred")]
        public ushort? Yellowred { get; set; }
        
        [JsonPropertyName("red")]
        public ushort? Red { get; set; }
    }
}
