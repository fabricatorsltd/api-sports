using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Basketball.QueryParams;

public sealed class GamesQuery : IQueryString
{
    public int? Id { get; init; }
    public DateOnly? Date { get; init; }
    public int? League { get; init; }
    public string? Season { get; init; }
    public int? Team { get; init; }
    public string? Timezone { get; init; }
    public string? H2H { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["league"] = League?.ToString(),
            ["season"] = Season,
            ["team"] = Team?.ToString(),
            ["timezone"] = Timezone,
            ["h2h"] = H2H
        };
    }
}

public sealed class GameLookupQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Ids { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["ids"] = Ids
        };
    }
}
