using Newtonsoft.Json;
using System;

namespace API_Football.SDK.Models
{
    public class Birth
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
