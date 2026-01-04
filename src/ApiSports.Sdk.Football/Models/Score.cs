using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class Score
    {
        [JsonPropertyName("halftime")]
        public HomeAway<ushort?>  Halftime { get; set; }
        
        [JsonPropertyName("fulltime")]
        public HomeAway<ushort?>  Fulltime { get; set; }
        
        [JsonPropertyName("extratime")]
        public HomeAway<ushort?>  Extratime { get; set; }
        
        [JsonPropertyName("penalty")]
        public HomeAway<ushort?>  Penalty { get; set; }
    }
}
