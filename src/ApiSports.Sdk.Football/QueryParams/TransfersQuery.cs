using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class TransfersQuery : IQueryString
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
