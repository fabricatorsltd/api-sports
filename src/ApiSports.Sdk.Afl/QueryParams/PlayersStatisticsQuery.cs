using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Afl.QueryParams;

public sealed class PlayersStatisticsQuery : IQueryString
{
    public required int Id { get; init; }
    public required int Season { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id.ToString(),
            ["season"] = Season.ToString()
        };
    }
}
