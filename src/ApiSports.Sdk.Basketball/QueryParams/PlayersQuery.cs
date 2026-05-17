using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Basketball.QueryParams;

public sealed class PlayersQuery : IQueryString
{
    public int? Id { get; init; }
    public int? Team { get; init; }
    public string? Season { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["team"] = Team?.ToString(),
            ["season"] = Season,
            ["search"] = Search
        };
    }
}
