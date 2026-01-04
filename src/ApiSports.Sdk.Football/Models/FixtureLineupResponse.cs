using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class FixtureLineupResponse
    {
        [JsonPropertyName("team")]
        public FixtureLineupTeam? Team { get; set; }

        [JsonPropertyName("coach")]
        public FixtureLineupCoach? Coach { get; set; }

        [JsonPropertyName("formation")]
        public string? Formation { get; set; }

        [JsonPropertyName("startXI")]
        public List<FixtureLineupPlayerEntry>? StartXI { get; set; }

        [JsonPropertyName("substitutes")]
        public List<FixtureLineupPlayerEntry>? Substitutes { get; set; }
    }

    public sealed class FixtureLineupTeam
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("colors")]
        public FixtureLineupTeamColors? Colors { get; set; }
    }

    public sealed class FixtureLineupTeamColors
    {
        [JsonPropertyName("player")]
        public FixtureLineupTeamColorSet? Player { get; set; }

        [JsonPropertyName("goalkeeper")]
        public FixtureLineupTeamColorSet? Goalkeeper { get; set; }
    }

    public sealed class FixtureLineupTeamColorSet
    {
        [JsonPropertyName("primary")]
        public string? Primary { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("border")]
        public string? Border { get; set; }
    }

    public sealed class FixtureLineupCoach
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("photo")]
        public string? Photo { get; set; }
    }

    public sealed class FixtureLineupPlayerEntry
    {
        [JsonPropertyName("player")]
        public FixtureLineupPlayer? Player { get; set; }
    }

    public sealed class FixtureLineupPlayer
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("number")]
        public int? Number { get; set; }

        [JsonPropertyName("pos")]
        public string? Position { get; set; }

        [JsonPropertyName("grid")]
        public string? Grid { get; set; }
    }
}
