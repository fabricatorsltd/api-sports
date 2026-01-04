using System.Text.Json.Serialization;
using ApiSports.Sdk.Football.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct PlayerGames
    {
        [JsonPropertyName("appearences")]
        public ushort? Appearences { get; set; }
        
        [JsonPropertyName("lineups")]
        public ushort? Lineups { get; set; }
        
        [JsonPropertyName("minutes")]
        public uint? Minutes { get; set; }

        [JsonPropertyName("number")]
        public ushort? Number { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("rating")]
        [JsonConverter(typeof(NullableDoubleFromStringOrNumberConverter))]
        // API returns numeric values as strings; normalized to double.
        public double? Rating { get; set; }

        [JsonPropertyName("captain")]
        public bool Captain { get; set; }
    }
}
