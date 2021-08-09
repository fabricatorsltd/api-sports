using Newtonsoft.Json;
using System;

namespace API_Football.SDK.Models
{
    public class CoachCareer
    {
        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime? End { get; set; }
    }
}
