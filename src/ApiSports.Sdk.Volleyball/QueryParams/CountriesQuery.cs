using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Volleyball.QueryParams;

public sealed class CountriesQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Code { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["code"] = Code,
            ["search"] = Search
        };
    }
}
