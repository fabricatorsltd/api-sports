using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class OddsMappingQuery : IQueryString
{
    public int? Page { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["page"] = Page?.ToString()
        };
    }
}
