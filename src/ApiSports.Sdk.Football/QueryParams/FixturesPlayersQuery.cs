using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class FixturesPlayersQuery : IQueryString
{
    public required int Fixture { get; init; }
    public int? Team { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fixture"] = Fixture.ToString(),
            ["team"] = Team?.ToString(),
        };
    }
}
