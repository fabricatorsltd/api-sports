using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Formula1.QueryParams;

public sealed class RankingsDriversQuery : IQueryString
{
    public required int Season { get; init; }
    public int? Driver { get; init; }
    public int? Team { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["season"] = Season.ToString(),
            ["driver"] = Driver?.ToString(),
            ["team"] = Team?.ToString()
        };
    }
}
