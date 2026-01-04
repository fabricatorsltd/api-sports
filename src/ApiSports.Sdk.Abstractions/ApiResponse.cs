using System.Text.Json;

namespace ApiSports.Sdk.Abstractions;

public sealed class ApiResponse<TResponse>
{
    public string? Get { get; init; }

    public JsonElement? Parameters { get; init; }

    // errors could be [] or {} or strings
    public JsonElement? Errors { get; init; }

    public int Results { get; init; }

    public ApiPaging? Paging { get; init; }

    public TResponse? Response { get; init; }
}
