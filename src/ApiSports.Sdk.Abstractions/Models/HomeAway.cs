using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Abstractions.Models;


public sealed class HomeAway<T>
{
    [JsonPropertyName("home")]
    public T? Home { get; init; }

    [JsonPropertyName("away")]
    public T? Away { get; init; }
}
