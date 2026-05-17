using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Afl.QueryParams;

public sealed class GameLookupQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Ids { get; init; }
    public DateOnly? Date { get; init; }
    public string? Timezone { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["ids"] = Ids,
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["timezone"] = Timezone
        };
    }
}
