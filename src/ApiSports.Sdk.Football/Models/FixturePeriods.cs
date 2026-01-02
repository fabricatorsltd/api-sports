using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct FixturePeriods
    {
        [JsonPropertyName("first")]
        public uint? First { get; set; }
        
        [JsonPropertyName("second")]
        public uint? Second { get; set; }
    }
}
