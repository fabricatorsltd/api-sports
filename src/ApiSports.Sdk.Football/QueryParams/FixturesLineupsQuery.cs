using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class FixturesLineupsQuery : IQueryString
{
    public required int Fixture { get; init; }
    public int? Team { get; init; }
    public int? Player { get; init; }
    public string? Type { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fixture"] = Fixture.ToString(),
            ["team"] = Team?.ToString(),
            ["player"] = Player?.ToString(),
            ["type"] = Type
        };
    }
}
