using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Score
    {
        [JsonConverter(typeof(ApiTupleConverter<ushort?>))]
        public (ushort? home, ushort? away) Halftime { get; set; }
        [JsonConverter(typeof(ApiTupleConverter<ushort?>))]
        public (ushort? home, ushort? away) Fulltime { get; set; }
        [JsonConverter(typeof(ApiTupleConverter<ushort?>))]
        public (ushort? home, ushort? away) Extratime { get; set; }
        [JsonConverter(typeof(ApiTupleConverter<ushort?>))]
        public (ushort? home, ushort? away) Penalty { get; set; }
    }
}
