using Newtonsoft.Json;
using System.Collections.Generic;

namespace API_Football.SDK.Models
{
    public class Coach
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public ushort Age { get; set; }

        [JsonProperty("birth")]
        public Birth Birth { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("career")]
        public List<CoachCareer> Career { get; set; }
    }
}
