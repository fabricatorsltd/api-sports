using System.Text.Json.Serialization;
using ApiSports.Sdk.Abstractions.Models;

namespace ApiSports.Sdk.Football.Models
{
    public class Prediction
    {
        [JsonPropertyName("winner")]
        public Team Winner { get; set; }

        [JsonPropertyName("win_or_draw")]
        public bool WinOrDraw { get; set; }

        [JsonPropertyName("under_over")]
        public string UnderOver { get; set; }

        [JsonPropertyName("goals")]
        public HomeAway<string> Goals { get; set; }

        [JsonPropertyName("advice")]
        public string Advice { get; set; }

        [JsonPropertyName("percent")]
        public HomeDraw<string> Percent { get; set; }
    }
}
