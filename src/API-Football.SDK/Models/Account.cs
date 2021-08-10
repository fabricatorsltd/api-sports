using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class Account
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}