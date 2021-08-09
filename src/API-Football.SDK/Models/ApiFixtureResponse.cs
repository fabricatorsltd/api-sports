using Newtonsoft.Json;
using System.Collections.Generic;

namespace API_Football.SDK.Models
{
    public class ApiFixtureResponse
    {
        [JsonProperty("fixture")]
        public Fixture Fixture { get; set; }
        
        [JsonProperty("league")]
        public League League { get; set; }
        
        [JsonProperty("teams")]
        [JsonConverter(typeof(ApiTupleConverter<Team>))]
        public (Team home, Team away) Teams { get; set; }
        
        [JsonProperty("goals")]
        public HomeAway<ushort?> Goals { get; set; }
        
        [JsonProperty("score")]
        public Score Score { get; set; }
        
        [JsonProperty("events")]
        public List<FixtureEvent> Events { get; set; }
    }
}
