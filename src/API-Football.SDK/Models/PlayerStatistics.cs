using Newtonsoft.Json;

namespace API_Football.SDK.Models
{
    public class PlayerStatistics
    {
        [JsonProperty("team")]
        public Team Team { get; set; }
        
        [JsonProperty("league")]
        public League League { get; set; }
        
        [JsonProperty("games")]
        public PlayerGames Games { get; set; }
        
        [JsonProperty("substitutes")]
        public PlayerSubstitutes Substitutes { get; set; }
        
        [JsonProperty("shots")]
        public PlayerShots Shots { get; set; }
        
        [JsonProperty("goals")]
        public PlayerGoals Goals { get; set; }
        
        [JsonProperty("passes")]
        public PlayerPasses Passes { get; set; }
        
        [JsonProperty("tackles")]
        public PlayerTackles Tackles { get; set; }
        
        [JsonProperty("duels")]
        public PlayerDuels Duels { get; set; }
        
        [JsonProperty("dribbles")]
        public PlayerDribbles Dribbles { get; set; }
        
        [JsonProperty("fouls")]
        public PlayerFouls Fouls { get; set; }
        
        [JsonProperty("cards")]
        public PlayerCards Cards { get; set; }
        
        [JsonProperty("penalty")]
        public PlayerPenalty Penalty { get; set; }
    }
}