using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Football.Models
{
    public class PredictionComparison
    {
        [JsonPropertyName("form")]
        public HomeAway<string?>? Form { get; set; }

        [JsonPropertyName("att")]
        public HomeAway<string?>? Att { get; set; }

        [JsonPropertyName("dev")]
        public HomeAway<string?>? Def { get; set; }

        [JsonPropertyName("poisson_distribution")]
        public HomeAway<string?>? PoissonDistribution { get; set; }

        [JsonPropertyName("h2h")]
        public HomeAway<string?>? HeadToHead { get; set; }

        [JsonPropertyName("goals")]
        public HomeAway<string?>? Goals { get; set; }

        [JsonPropertyName("total")]
        public HomeAway<string?>? Total { get; set; }
    }
}
