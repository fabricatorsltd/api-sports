using Newtonsoft.Json;
using System.Collections.Generic;

namespace API_Football.SDK.Models
{
    public class ApiFixtureResponse
    {
        public Fixture Fixture { get; set; }
        public League League { get; set; }
        [JsonConverter(typeof(ApiTupleConverter<Team>))]
        public (Team home, Team away) Teams { get; set; }
        [JsonConverter(typeof(ApiTupleConverter<ushort>))]
        public (ushort home, ushort away) Goals { get; set; }
        public Score Score { get; set; }
        public List<FixtureEvent> Events { get; set; }
    }
}
