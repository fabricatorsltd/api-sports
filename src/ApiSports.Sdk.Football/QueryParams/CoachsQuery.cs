using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class CoachsQuery : IQueryString
{
    public int? Id { get; init; }
    public int? Team { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["team"] = Team?.ToString(),
            ["search"] = Search
        };
    }
}
