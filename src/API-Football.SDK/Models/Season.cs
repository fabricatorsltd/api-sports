using System;
using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Season
    {
        [JsonProperty("year")]
        public ushort Year { get; set; }
        
        [JsonProperty("start")]
        public DateTime? Start { get; set; }
        
        [JsonProperty("end")]
        public DateTime? End { get; set; }
        
        [JsonProperty("current")]
        public bool Current { get; set; }
        
        [JsonProperty("coverage")]
        public Coverage Coverage { get; set; }
    }    
}