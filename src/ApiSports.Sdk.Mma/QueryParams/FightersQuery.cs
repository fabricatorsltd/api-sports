using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Mma.QueryParams;

public sealed class FightersQuery : IQueryString
{
    public int? Id { get; init; }
    public int? Team { get; init; }
    public string? Name { get; init; }
    public string? Category { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["team"] = Team?.ToString(),
            ["name"] = Name,
            ["category"] = Category,
            ["search"] = Search
        };
    }
}

public sealed class FighterRecordsQuery : IQueryString
{
    public required int Id { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id.ToString()
        };
    }
}
