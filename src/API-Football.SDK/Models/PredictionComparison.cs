using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class PredictionComparison
    {
        [JsonProperty("form")]
        [JsonConverter(typeof(ApiTupleConverter<string>))]
        public (string home, string away) Form { get; set; }

        [JsonProperty("att")]
        [JsonConverter(typeof(ApiTupleConverter<string>))]
        public (string home, string away) Att { get; set; }

        [JsonProperty("dev")]
        [JsonConverter(typeof(ApiTupleConverter<string>))]
        public (string home, string away) Def { get; set; }

        [JsonProperty("poisson_distribution")]
        [JsonConverter(typeof(ApiTupleConverter<string>))]
        public (string home, string away) PoissonDistribution { get; set; }

        [JsonProperty("h2h")]
        [JsonConverter(typeof(ApiTupleConverter<string>))]
        public (string home, string away) HeadToHead { get; set; }

        [JsonProperty("goals")]
        [JsonConverter(typeof(ApiTupleConverter<string>))]
        public (string home, string away) Goals { get; set; }

        [JsonProperty("total")]
        [JsonConverter(typeof(ApiTupleConverter<string>))]
        public (string home, string away) Total { get; set; }
    }
}
