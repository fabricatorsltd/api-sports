using System.Text.Json.Serialization;
using ApiSports.Sdk.Football.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class FixturePlayerResponse
    {
        [JsonPropertyName("team")]
        public FixturePlayerTeam? Team { get; set; }

        [JsonPropertyName("players")]
        public List<FixturePlayer>? Players { get; set; }
    }

    public sealed class FixturePlayerTeam
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("update")]
        public DateTimeOffset? Update { get; set; }
    }

    public sealed class FixturePlayer
    {
        [JsonPropertyName("player")]
        public FixturePlayerInfo? Player { get; set; }

        [JsonPropertyName("statistics")]
        public List<FixturePlayerStatistics>? Statistics { get; set; }
    }

    public sealed class FixturePlayerInfo
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("photo")]
        public string? Photo { get; set; }
    }

    public sealed class FixturePlayerStatistics
    {
        [JsonPropertyName("games")]
        public FixturePlayerGames? Games { get; set; }

        [JsonPropertyName("offsides")]
        public int? Offsides { get; set; }

        [JsonPropertyName("shots")]
        public PlayerShots? Shots { get; set; }

        [JsonPropertyName("goals")]
        public PlayerGoals? Goals { get; set; }

        [JsonPropertyName("passes")]
        public FixturePlayerPasses? Passes { get; set; }

        [JsonPropertyName("tackles")]
        public PlayerTackles? Tackles { get; set; }

        [JsonPropertyName("duels")]
        public PlayerDuels? Duels { get; set; }

        [JsonPropertyName("dribbles")]
        public PlayerDribbles? Dribbles { get; set; }

        [JsonPropertyName("fouls")]
        public PlayerFouls? Fouls { get; set; }

        [JsonPropertyName("cards")]
        public PlayerCards? Cards { get; set; }

        [JsonPropertyName("penalty")]
        public PlayerPenalty? Penalty { get; set; }
    }

    public sealed class FixturePlayerGames
    {
        [JsonPropertyName("minutes")]
        public uint? Minutes { get; set; }

        [JsonPropertyName("number")]
        public ushort? Number { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("rating")]
        [JsonConverter(typeof(NullableDoubleFromStringOrNumberConverter))]
        public double? Rating { get; set; }

        [JsonPropertyName("captain")]
        public bool? Captain { get; set; }

        [JsonPropertyName("substitute")]
        public bool? Substitute { get; set; }
    }

    public sealed class FixturePlayerPasses
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("key")]
        public int? Key { get; set; }

        [JsonPropertyName("accuracy")]
        public string? Accuracy { get; set; }
    }
}
