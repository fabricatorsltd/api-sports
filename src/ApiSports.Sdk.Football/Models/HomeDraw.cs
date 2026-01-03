using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public struct HomeDraw<T>
    {
        [JsonPropertyName("home")]
        public T Home { get; set; }
        
        [JsonPropertyName("draw")]
        public T Draw { get; set; }
        
        [JsonPropertyName("away")]
        public T Away { get; set; }
    }
}
