using Newtonsoft.Json;
using System;

namespace API_Football.SDK.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        public string Referee { get; set; }
        public string Timezone { get; set; }
        public DateTime Date { get; set; }
        public int Timestamp { get; set; }
        [JsonProperty("periods")]
        [JsonConverter(typeof(ApiTupleConverter<int?>))]
        public (int? first, int? second) Periods { get; set; }
        public Venue Venue { get; set; }
        [JsonProperty("status")]
        public FixtureStatus FixtureStatus { get; set; }
    }
}