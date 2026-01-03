using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class PlayersSeasonsQuery : IQueryString
{
    public required int Player { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["player"] = Player.ToString()
        };
    }
}
