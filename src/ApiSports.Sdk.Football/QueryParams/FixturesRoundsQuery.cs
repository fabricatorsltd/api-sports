using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class FixturesRoundsQuery : IQueryString
{
    public bool? Current { get; init; }
    public required int League { get; init; }
    public required int Season { get; init; }
    public bool? Dates { get; init; }
    public string? Timezone { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["current"] = Current?.ToString().ToLowerInvariant(),
            ["league"] = League.ToString(),
            ["season"] = Season.ToString(),
            ["dates"] = Dates?.ToString().ToLowerInvariant(),
            ["timezone"] = Timezone
        };
    }
}
