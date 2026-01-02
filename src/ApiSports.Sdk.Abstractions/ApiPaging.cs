using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Abstractions;

public sealed class ApiPaging
{
    [JsonPropertyName("current")]
    public int Current { get; init; }

    [JsonPropertyName("total")]
    public int Total { get; init; }
}
