using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Hockey.QueryParams;

public sealed class StandingsQuery : IQueryString
{
    public required int League { get; init; }
    public required int Season { get; init; }
    public int? Team { get; init; }
    public string? Stage { get; init; }
    public string? Group { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League.ToString(),
            ["season"] = Season.ToString(),
            ["team"] = Team?.ToString(),
            ["stage"] = Stage,
            ["group"] = Group
        };
    }
}

public sealed class StandingsLookupQuery : IQueryString
{
    public required int League { get; init; }
    public required int Season { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League.ToString(),
            ["season"] = Season.ToString()
        };
    }
}
