using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerPenalty
    {
        [JsonPropertyName("won")]
        public ushort? Won { get; set;  }
        
        [JsonPropertyName("committed")]
        public ushort? Committed { get; set; }
        
        [JsonPropertyName("scored")]
        public ushort? Scored { get; set; }
        
        [JsonPropertyName("missed")]
        public ushort? Missed { get; set; }
        
        [JsonPropertyName("saved")]
        public ushort? Saved { get; set; }
    }
}
