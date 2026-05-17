using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Rugby.QueryParams;

public sealed class TeamsQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public int? CountryId { get; init; }
    public string? Country { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["country_id"] = CountryId?.ToString(),
            ["country"] = Country,
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["search"] = Search
        };
    }
}

public sealed class TeamsStatisticsQuery : IQueryString
{
    public required int League { get; init; }
    public required int Season { get; init; }
    public required int Team { get; init; }
    public DateOnly? Date { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League.ToString(),
            ["season"] = Season.ToString(),
            ["team"] = Team.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd")
        };
    }
}
