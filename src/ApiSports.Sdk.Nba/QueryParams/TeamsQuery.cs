using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nba.QueryParams;

public sealed class TeamsQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Code { get; init; }
    public string? League { get; init; }
    public string? Conference { get; init; }
    public string? Division { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["code"] = Code,
            ["league"] = League,
            ["conference"] = Conference,
            ["division"] = Division,
            ["search"] = Search
        };
    }
}

public sealed class TeamsStatisticsQuery : IQueryString
{
    public required int Id { get; init; }
    public required int Season { get; init; }
    public int? Stage { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id.ToString(),
            ["season"] = Season.ToString(),
            ["stage"] = Stage?.ToString()
        };
    }
}
