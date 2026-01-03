using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class PlayersSquadsQuery : IQueryString
{
    public int? Team { get; init; }
    public int? Player { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["team"] = Team?.ToString(),
            ["player"] = Player?.ToString()
        };
    }
}
