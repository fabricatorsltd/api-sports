using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Formula1.QueryParams;

public sealed class RankingsTeamsQuery : IQueryString
{
    public required string Season { get; init; }
    public int? Team { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["season"] = Season,
            ["team"] = Team?.ToString()
        };
    }
}
