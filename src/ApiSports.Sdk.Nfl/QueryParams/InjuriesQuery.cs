using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nfl.QueryParams;

public sealed class InjuriesQuery : IQueryString
{
    public int? Player { get; init; }
    public int? Team { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["player"] = Player?.ToString(),
            ["team"] = Team?.ToString()
        };
    }
}
