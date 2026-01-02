using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public class PlayerStatistics
    {
        [JsonPropertyName("team")]
        public Team Team { get; set; }
        
        [JsonPropertyName("league")]
        public League League { get; set; }
        
        [JsonPropertyName("games")]
        public PlayerGames Games { get; set; }
        
        [JsonPropertyName("substitutes")]
        public PlayerSubstitutes Substitutes { get; set; }
        
        [JsonPropertyName("shots")]
        public PlayerShots Shots { get; set; }
        
        [JsonPropertyName("goals")]
        public PlayerGoals Goals { get; set; }
        
        [JsonPropertyName("passes")]
        public PlayerPasses Passes { get; set; }
        
        [JsonPropertyName("tackles")]
        public PlayerTackles Tackles { get; set; }
        
        [JsonPropertyName("duels")]
        public PlayerDuels Duels { get; set; }
        
        [JsonPropertyName("dribbles")]
        public PlayerDribbles Dribbles { get; set; }
        
        [JsonPropertyName("fouls")]
        public PlayerFouls Fouls { get; set; }
        
        [JsonPropertyName("cards")]
        public PlayerCards Cards { get; set; }
        
        [JsonPropertyName("penalty")]
        public PlayerPenalty Penalty { get; set; }
    }
}
