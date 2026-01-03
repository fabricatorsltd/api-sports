using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class PlayersTopScorersQuery : IQueryString
{
    public required int League { get; init; }
    public required int Season { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League.ToString(),
            ["season"] = Season.ToString()
        };
    }
}
