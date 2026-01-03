using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class Account
    {
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
