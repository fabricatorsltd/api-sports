using Newtonsoft.Json;
using System.Collections.Generic;

namespace API_Football.SDK.Models
{
    public class ApiPredictionsResponse
    {
        [JsonProperty("predictions")]
        public Prediction Predictions { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("teams")]
        [JsonConverter(typeof(ApiTupleConverter<Team>))]
        public (Team home, Team away) Teams { get; set; }

        [JsonProperty("comparison")]
        public PredictionComparison Comparison { get; set; }

        [JsonProperty("h2h")]
        public List<HeadToHead> HeadToHeads { get; set; }
    }
}
