using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class CountriesQuery : IQueryString
{
    public string? Name { get; init; }
    public string? Code { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["name"] = Name,
            ["code"] = Code,
            ["search"] = Search
        };
    }
}
