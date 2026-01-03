using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Football.Models
{
    public class ApiPredictionsResponse
    {
        [JsonPropertyName("predictions")]
        public Prediction Predictions { get; set; }

        [JsonPropertyName("league")]
        public League League { get; set; }

        [JsonPropertyName("teams")]
        public HomeAway<Team?>? Teams { get; set; }

        [JsonPropertyName("comparison")]
        public PredictionComparison Comparison { get; set; }

        [JsonPropertyName("h2h")]
        public List<HeadToHead> HeadToHeads { get; set; }
    }
}
