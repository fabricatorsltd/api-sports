using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class LeaguesQuery : IQueryString
{
    public int? Season { get; init; }
    public bool? Current { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["season"] = Season?.ToString(),
            ["current"] = Current?.ToString().ToLowerInvariant()
        };
    }
}
