using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nfl.QueryParams;

public sealed class TeamsQuery : IQueryString
{
    public int? Id { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }
    public string? Name { get; init; }
    public string? Code { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["name"] = Name,
            ["code"] = Code,
            ["search"] = Search
        };
    }
}
