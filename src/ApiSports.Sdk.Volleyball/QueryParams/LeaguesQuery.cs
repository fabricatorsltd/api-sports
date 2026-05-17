using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Volleyball.QueryParams;

public sealed class LeaguesQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public int? CountryId { get; init; }
    public string? Country { get; init; }
    public string? Type { get; init; }
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
            ["type"] = Type,
            ["season"] = Season?.ToString(),
            ["search"] = Search
        };
    }
}
