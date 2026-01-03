using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class FixturesStatisticsQuery : IQueryString
{
    public required int Fixture { get; init; }
    public int? Team { get; init; }
    public bool? Type { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fixture"] = Fixture.ToString(),
            ["team"] = Team?.ToString(),
            ["type"] = Type?.ToString().ToLowerInvariant(),
        };
    }
}
