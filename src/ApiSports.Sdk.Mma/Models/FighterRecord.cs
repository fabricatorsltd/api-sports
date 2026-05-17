using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Mma.Models;

public sealed class FighterRecord
{
    [JsonPropertyName("fighter")]
    public FighterSummary? Fighter { get; init; }

    [JsonPropertyName("total")]
    public FighterRecordTotals? Total { get; init; }

    [JsonPropertyName("ko")]
    public FighterRecordWinLoss? Ko { get; init; }

    [JsonPropertyName("sub")]
    public FighterRecordWinLoss? Sub { get; init; }
}

public sealed class FighterSummary
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("photo")]
    public string? Photo { get; init; }
}

public sealed class FighterRecordTotals
{
    [JsonPropertyName("win")]
    public int? Win { get; init; }

    [JsonPropertyName("loss")]
    public int? Loss { get; init; }

    [JsonPropertyName("draw")]
    public int? Draw { get; init; }
}

public sealed class FighterRecordWinLoss
{
    [JsonPropertyName("win")]
    public int? Win { get; init; }

    [JsonPropertyName("loss")]
    public int? Loss { get; init; }
}
