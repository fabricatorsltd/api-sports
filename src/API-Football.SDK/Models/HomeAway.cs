using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct HomeAway<T>
    {
        [JsonProperty("home")]
        public T Home { get; set; }
        
        [JsonProperty("away")]
        public T Away { get; set; }
    }
}