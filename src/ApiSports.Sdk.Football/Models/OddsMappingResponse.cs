using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class OddsMappingResponse
    {
        [JsonPropertyName("league")]
        public OddsMappingLeague? League { get; set; }

        [JsonPropertyName("fixture")]
        public OddsMappingFixture? Fixture { get; set; }

        [JsonPropertyName("update")]
        public DateTimeOffset? Update { get; set; }
    }

    public sealed class OddsMappingLeague
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("season")]
        public int? Season { get; set; }
    }

    public sealed class OddsMappingFixture
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonPropertyName("timestamp")]
        public int? Timestamp { get; set; }
    }
}
