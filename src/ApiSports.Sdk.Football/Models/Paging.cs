using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Paging
    {
        [JsonPropertyName("current")]
        public ushort Current { get; set; }
        
        [JsonPropertyName("total")]
        public ushort Total { get; set; }
    }
}
