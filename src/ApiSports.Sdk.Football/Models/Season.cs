using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Season
    {
        [JsonPropertyName("year")]
        public ushort Year { get; set; }
        
        [JsonPropertyName("start")]
        public DateTime? Start { get; set; }
        
        [JsonPropertyName("end")]
        public DateTime? End { get; set; }
        
        [JsonPropertyName("current")]
        public bool Current { get; set; }
        
        [JsonPropertyName("coverage")]
        public Coverage Coverage { get; set; }
    }    
}
