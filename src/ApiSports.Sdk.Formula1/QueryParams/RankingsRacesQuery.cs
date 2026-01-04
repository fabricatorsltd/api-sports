using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Formula1.QueryParams;

public sealed class RankingsRacesQuery : IQueryString
{
    public required int Race { get; init; }
    public int? Team { get; init; }
    public int? Driver { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["race"] = Race.ToString(),
            ["team"] = Team?.ToString(),
            ["driver"] = Driver?.ToString()
        };
    }
}
