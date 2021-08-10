using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Paging
    {
        [JsonProperty("current")]
        public ushort Current { get; set; }
        
        [JsonProperty("total")]
        public ushort Total { get; set; }
    }
}