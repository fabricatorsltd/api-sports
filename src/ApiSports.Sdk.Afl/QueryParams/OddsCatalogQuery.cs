using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Afl.QueryParams;

public sealed class OddsCatalogQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["search"] = Search
        };
    }
}
