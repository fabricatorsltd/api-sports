using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class PlayersQuery : IQueryString
{
    public int? Id { get; init; }
    public int? Team { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }
    public string? Search { get; init; }
    public int? Page { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["team"] = Team?.ToString(),
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["search"] = Search,
            ["page"] = Page?.ToString()
        };
    }
}
