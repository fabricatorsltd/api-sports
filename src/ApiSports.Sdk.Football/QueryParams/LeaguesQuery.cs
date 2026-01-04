using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class LeaguesQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Country { get; init; }
    public string? Code { get; init; }
    public int? Season { get; init; }
    public int? Team { get; init; }
    public string? Type { get; init; }
    public bool? Current { get; init; }
    public string? Search { get; init; }
    public int? Last { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["country"] = Country,
            ["code"] = Code,
            ["season"] = Season?.ToString(),
            ["team"] = Team?.ToString(),
            ["type"] = Type,
            ["current"] = Current?.ToString().ToLowerInvariant(),
            ["search"] = Search,
            ["last"] = Last?.ToString()
        };
    }
}
