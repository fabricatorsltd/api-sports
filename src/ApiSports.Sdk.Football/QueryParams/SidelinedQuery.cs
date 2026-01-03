using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class SidelinedQuery : IQueryString
{
    public int? Player { get; init; }
    public int? Coach { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["player"] = Player?.ToString(),
            ["coach"] = Coach?.ToString()
        };
    }
}
