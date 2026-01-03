using System.Text.Json.Serialization;

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
        public double? Rating { get; set; }

        [JsonPropertyName("captain")]
        public bool Captain { get; set; }
    }
}
