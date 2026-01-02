using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerSubstitutes
    {
        [JsonPropertyName("in")]
        public ushort? In { get; set; }
        
        [JsonPropertyName("out")]
        public ushort? Out { get; set; }
        
        [JsonPropertyName("bench")]
        public ushort? Bench { get; set; }
    }
}
