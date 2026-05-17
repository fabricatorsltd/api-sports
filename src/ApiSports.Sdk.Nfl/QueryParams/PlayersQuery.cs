using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nfl.QueryParams;

public sealed class PlayersQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public int? Team { get; init; }
    public int? Season { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["team"] = Team?.ToString(),
            ["season"] = Season?.ToString(),
            ["search"] = Search
        };
    }
}

public sealed class PlayersStatisticsQuery : IQueryString
{
    public int? Id { get; init; }
    public int? Team { get; init; }
    public required int Season { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["team"] = Team?.ToString(),
            ["season"] = Season.ToString()
        };
    }
}
