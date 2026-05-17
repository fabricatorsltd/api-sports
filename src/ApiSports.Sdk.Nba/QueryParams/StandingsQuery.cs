using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nba.QueryParams;

public sealed class StandingsQuery : IQueryString
{
    public required string League { get; init; }
    public required int Season { get; init; }
    public int? Team { get; init; }
    public string? Conference { get; init; }
    public string? Division { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League,
            ["season"] = Season.ToString(),
            ["team"] = Team?.ToString(),
            ["conference"] = Conference,
            ["division"] = Division
        };
    }
}
