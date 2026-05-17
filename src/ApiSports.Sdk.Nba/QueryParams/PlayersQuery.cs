using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nba.QueryParams;

public sealed class PlayersQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public int? Team { get; init; }
    public int? Season { get; init; }
    public string? Country { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["team"] = Team?.ToString(),
            ["season"] = Season?.ToString(),
            ["country"] = Country,
            ["search"] = Search
        };
    }
}

public sealed class PlayersStatisticsQuery : IQueryString
{
    public int? Id { get; init; }
    public int? Game { get; init; }
    public int? Team { get; init; }
    public int? Season { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["game"] = Game?.ToString(),
            ["team"] = Team?.ToString(),
            ["season"] = Season?.ToString()
        };
    }
}
