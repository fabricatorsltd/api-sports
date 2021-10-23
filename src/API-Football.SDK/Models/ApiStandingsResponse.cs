using System.Collections.Generic;
using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class ApiStandingsResponse
    {
        [JsonProperty("league")]
        public League League { get; set; }
    }
}