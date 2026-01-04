using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class PlayerSquadResponse
    {
        [JsonPropertyName("team")]
        public PlayerSquadTeam? Team { get; set; }

        [JsonPropertyName("players")]
        public List<PlayerSquadMember>? Players { get; set; }
    }

    public sealed class PlayerSquadTeam
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }

    public sealed class PlayerSquadMember
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("age")]
        public int? Age { get; set; }

        [JsonPropertyName("number")]
        public int? Number { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("photo")]
        public string? Photo { get; set; }
    }
}
