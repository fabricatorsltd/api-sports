using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Formula1.QueryParams;

public sealed class TeamsQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["search"] = Search
        };
    }
}
