using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class FixturesStatisticsQuery : IQueryString
{
    public required int Fixture { get; init; }
    public int? Team { get; init; }
    public string? Type { get; init; }
    public bool? Half { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fixture"] = Fixture.ToString(),
            ["team"] = Team?.ToString(),
            ["type"] = Type,
            ["half"] = Half?.ToString().ToLowerInvariant()
        };
    }
}
