using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class OddsLiveQuery : IQueryString
{
    public int? Fixture { get; init; }
    public int? League { get; init; }
    public int? Bet { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fixture"] = Fixture?.ToString(),
            ["league"] = League?.ToString(),
            ["bet"] = Bet?.ToString()
        };
    }
}
