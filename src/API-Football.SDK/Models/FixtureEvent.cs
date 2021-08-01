using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class FixtureEvent
    {
        [JsonConverter(typeof(ApiTupleConverter<ushort?>))]
        public (ushort? elapsed, ushort? extra) Time { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
        public Player Assist { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Comments { get; set; }
    }
}
