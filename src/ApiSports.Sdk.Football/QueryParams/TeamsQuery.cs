using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class TeamsQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Country { get; init; }
    public string? Search { get; init; }
    public int? Season { get; init; }
    public int? League { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["country"] = Country,
            ["search"] = Search,
            ["season"] = Season?.ToString(),
            ["league"] = League?.ToString()
        };
    }
}

