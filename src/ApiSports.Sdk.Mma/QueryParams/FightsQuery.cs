using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Mma.QueryParams;

public sealed class FightsQuery : IQueryString
{
    public int? Id { get; init; }
    public DateOnly? Date { get; init; }
    public int? Season { get; init; }
    public int? Fighter { get; init; }
    public string? Category { get; init; }
    public string? Timezone { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["season"] = Season?.ToString(),
            ["fighter"] = Fighter?.ToString(),
            ["category"] = Category,
            ["timezone"] = Timezone
        };
    }
}

public sealed class FightLookupQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Ids { get; init; }
    public DateOnly? Date { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["ids"] = Ids,
            ["date"] = Date?.ToString("yyyy-MM-dd")
        };
    }
}
