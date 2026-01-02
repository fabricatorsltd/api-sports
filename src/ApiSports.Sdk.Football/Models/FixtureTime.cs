using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct FixtureTime
    {
        [JsonPropertyName("elapsed")]
        public ushort? Elapsed { get; set; }
        
        [JsonPropertyName("extra")]
        public ushort? Extra { get; set; }
    }
}
