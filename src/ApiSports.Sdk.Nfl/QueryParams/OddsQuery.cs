using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nfl.QueryParams;

public sealed class OddsQuery : IQueryString
{
    public required int Game { get; init; }
    public int? Bookmaker { get; init; }
    public int? Bet { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["game"] = Game.ToString(),
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
