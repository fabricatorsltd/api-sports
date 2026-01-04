using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class SidelinedQuery : IQueryString
{
    public int? Player { get; init; }
    public string? Players { get; init; }
    public int? Coach { get; init; }
    public string? Coachs { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["player"] = Player?.ToString(),
            ["players"] = Players,
            ["coach"] = Coach?.ToString(),
            ["coachs"] = Coachs
        };
    }
}
