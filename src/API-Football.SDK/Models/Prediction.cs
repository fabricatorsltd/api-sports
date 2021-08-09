using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Prediction
    {
        [JsonProperty("winner")]
        public Team Winner { get; set; }

        [JsonProperty("win_or_draw")]
        public bool WinOrDraw { get; set; }

        [JsonProperty("under_over")]
        public string UnderOver { get; set; }

        [JsonProperty("goals")]
        public HomeAway<string> Goals { get; set; }

        [JsonProperty("advice")]
        public string Advice { get; set; }

        [JsonProperty("percent")]
        public HomeDraw<string> Percent { get; set; }
    }
}
