using Newtonsoft.Json;
using System;

namespace API_Football.SDK.Models
{
    public class Fixture
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("referee")]
        public string Referee { get; set; }
        
        [JsonProperty("rimezone")]
        public string Timezone { get; set; }
        
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
        
        [JsonProperty("periods")]
        public FixturePeriods Periods { get; set; }
        
        [JsonProperty("venue")]
        public Venue Venue { get; set; }
        
        [JsonProperty("status")]
        public FixtureStatus Status { get; set; }
    }
}