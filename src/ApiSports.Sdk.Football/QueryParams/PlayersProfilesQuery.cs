using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class PlayersProfilesQuery : IQueryString
{
    public int? Player { get; init; }
    public string? Search { get; init; }
    public int? Page { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["player"] = Player?.ToString(),
            ["search"] = Search,
            ["page"] = Page?.ToString()
        };
    }
}
