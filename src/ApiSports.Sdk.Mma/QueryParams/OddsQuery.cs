using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Mma.QueryParams;

public sealed class OddsQuery : IQueryString
{
    public int? Fight { get; init; }
    public DateOnly? Date { get; init; }
    public int? Bookmaker { get; init; }
    public int? Bet { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fight"] = Fight?.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["bookmaker"] = Bookmaker?.ToString(),
            ["bet"] = Bet?.ToString()
        };
    }
}

public sealed class OddsCatalogQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["search"] = Search
        };
    }
}
