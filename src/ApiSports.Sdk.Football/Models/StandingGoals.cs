using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class StandingGoals
    {
        [JsonPropertyName("for")]
        public ushort For { get; set; }
        
        [JsonPropertyName("against")]
        public ushort Against { get; set; }
    }
}
