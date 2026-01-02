using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class Fixture
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("referee")]
        public string? Referee { get; set; }
        
        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }
        
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }
        
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }
        
        [JsonPropertyName("periods")]
        public FixturePeriods? Periods { get; set; }
        
        [JsonPropertyName("venue")]
        public Venue? Venue { get; set; }
        
        [JsonPropertyName("status")]
        public FixtureStatus? Status { get; set; }
    }
}
