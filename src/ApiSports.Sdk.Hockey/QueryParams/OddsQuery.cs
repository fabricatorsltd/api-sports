using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Hockey.QueryParams;

public sealed class OddsQuery : IQueryString
{
    public int? League { get; init; }
    public int? Season { get; init; }
    public int? Game { get; init; }
    public int? Bookmaker { get; init; }
    public int? Bet { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["game"] = Game?.ToString(),
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
