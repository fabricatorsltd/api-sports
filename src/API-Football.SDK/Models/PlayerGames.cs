using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct PlayerGames
    {
        [JsonProperty("appearences")]
        public ushort? Appearences { get; set; }
        
        [JsonProperty("lineups")]
        public ushort? Lineups { get; set; }
        
        [JsonProperty("minutes")]
        public uint? Minutes { get; set; }

        [JsonProperty("number")]
        public ushort? Number { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("rating")]
        public double? Rating { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }
    }
}