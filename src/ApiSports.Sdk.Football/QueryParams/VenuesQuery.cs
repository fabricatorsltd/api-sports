using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class VenuesQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? City { get; init; }
    public string? Country { get; init; }
    public string? Search { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["name"] = Name,
            ["city"] = City,
            ["country"] = Country,
            ["search"] = Search,
        };
    }
}
