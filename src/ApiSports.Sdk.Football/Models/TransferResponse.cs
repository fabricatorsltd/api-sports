using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Models
{
    public sealed class TransferResponse
    {
        [JsonPropertyName("player")]
        public TransferPlayer? Player { get; set; }

        [JsonPropertyName("update")]
        public DateTimeOffset? Update { get; set; }

        [JsonPropertyName("transfers")]
        public List<TransferDetail>? Transfers { get; set; }
    }

    public sealed class TransferPlayer
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public sealed class TransferDetail
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("teams")]
        public TransferTeams? Teams { get; set; }
    }

    public sealed class TransferTeams
    {
        [JsonPropertyName("in")]
        public TransferTeam? In { get; set; }

        [JsonPropertyName("out")]
        public TransferTeam? Out { get; set; }
    }

    public sealed class TransferTeam
    {
        [JsonPropertyName("id")]
        public uint? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }
}
