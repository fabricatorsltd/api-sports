using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class OddsQuery : IQueryString
{
    public int? Fixture { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }
    public DateOnly? Date { get; init; }
    public string? Timezone { get; init; }
    public int? Page { get; init; }
    public int? Bookmaker { get; init; }
    public int? Bet { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fixture"] = Fixture?.ToString(),
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["timezone"] = Timezone,
            ["page"] = Page?.ToString(),
            ["bookmaker"] = Bookmaker?.ToString(),
            ["bet"] = Bet?.ToString()
        };
    }
}
