using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class OddsResponse
    {
        [JsonPropertyName("league")]
        public OddsLeague? League { get; set; }

        [JsonPropertyName("fixture")]
        public OddsFixture? Fixture { get; set; }

        [JsonPropertyName("teams")]
        public OddsLiveTeams? Teams { get; set; }

        [JsonPropertyName("status")]
        public OddsLiveStatus? Status { get; set; }

        [JsonPropertyName("update")]
        public DateTimeOffset? Update { get; set; }

        [JsonPropertyName("bookmakers")]
        public List<OddsBookmaker>? Bookmakers { get; set; }

        [JsonPropertyName("odds")]
        public List<OddsLiveBet>? Odds { get; set; }
    }

    public sealed class OddsLeague
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }

        [JsonPropertyName("flag")]
        public string? Flag { get; set; }

        [JsonPropertyName("season")]
        public int? Season { get; set; }
    }

    public sealed class OddsFixture
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonPropertyName("timestamp")]
        public int? Timestamp { get; set; }

        [JsonPropertyName("status")]
        public OddsFixtureStatus? Status { get; set; }
    }

    public sealed class OddsFixtureStatus
    {
        [JsonPropertyName("long")]
        public string? Long { get; set; }

        [JsonPropertyName("elapsed")]
        public int? Elapsed { get; set; }

        [JsonPropertyName("seconds")]
        public string? Seconds { get; set; }
    }

    public sealed class OddsLiveTeams
    {
        [JsonPropertyName("home")]
        public OddsLiveTeamScore? Home { get; set; }

        [JsonPropertyName("away")]
        public OddsLiveTeamScore? Away { get; set; }
    }

    public sealed class OddsLiveTeamScore
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("goals")]
        public int? Goals { get; set; }
    }

    public sealed class OddsLiveStatus
    {
        [JsonPropertyName("stopped")]
        public bool? Stopped { get; set; }

        [JsonPropertyName("blocked")]
        public bool? Blocked { get; set; }

        [JsonPropertyName("finished")]
        public bool? Finished { get; set; }
    }

    public sealed class OddsBookmaker
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("bets")]
        public List<OddsBookmakerBet>? Bets { get; set; }
    }

    public sealed class OddsBookmakerBet
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("values")]
        public List<OddsBookmakerBetValue>? Values { get; set; }
    }

    public sealed class OddsBookmakerBetValue
    {
        [JsonPropertyName("value")]
        public JsonElement? Value { get; set; }

        [JsonPropertyName("odd")]
        public string? Odd { get; set; }
    }

    public sealed class OddsLiveBet
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("values")]
        public List<OddsLiveBetValue>? Values { get; set; }
    }

    public sealed class OddsLiveBetValue
    {
        [JsonPropertyName("value")]
        public JsonElement? Value { get; set; }

        [JsonPropertyName("odd")]
        public string? Odd { get; set; }

        [JsonPropertyName("handicap")]
        public string? Handicap { get; set; }

        [JsonPropertyName("main")]
        public bool? Main { get; set; }

        [JsonPropertyName("suspended")]
        public bool? Suspended { get; set; }
    }
}
