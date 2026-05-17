using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Afl.QueryParams;

public sealed class OddsQuery : IQueryString
{
    public required int Game { get; init; }
    public int? Bookmaker { get; init; }
    public int? Bet { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["game"] = Game.ToString(),
            ["bookmaker"] = Bookmaker?.ToString(),
            ["bet"] = Bet?.ToString()
        };
    }
}
