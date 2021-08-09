using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public struct HomeDraw<T>
    {
        [JsonProperty("home")]
        public T Home { get; set; }
        
        [JsonProperty("draw")]
        public T Draw { get; set; }
        
        [JsonProperty("away")]
        public T Away { get; set; }
    }
}