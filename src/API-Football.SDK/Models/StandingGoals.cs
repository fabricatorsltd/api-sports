using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class StandingGoals
    {
        [JsonProperty("for")]
        public ushort For { get; set; }
        
        [JsonProperty("against")]
        public ushort Against { get; set; }
    }
}
