using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class FixturesRoundsQuery : IQueryString
{
    public bool? Current { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["current"] = Current?.ToString().ToLowerInvariant(),
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
        };
    }
}
