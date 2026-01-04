using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerPasses
    {
        [JsonPropertyName("total")]
        public ushort? Total { get; set;  }
        
        [JsonPropertyName("key")]
        public ushort? Key { get; set; }
        
        [JsonPropertyName("accuracy")]
        public ushort? Accuracy { get; set; }
    }
}
