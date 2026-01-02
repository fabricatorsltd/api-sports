using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerGoals
    {
        [JsonPropertyName("total")]
        public ushort? Total { get; set;  }
        
        [JsonPropertyName("conceded")]
        public ushort? Conceded { get; set; }
        
        [JsonPropertyName("assists")]
        public ushort? Assists { get; set; }
        
        [JsonPropertyName("saves")]
        public ushort? Saves { get; set; }
    }
}
