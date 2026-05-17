using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Mma.QueryParams;

public sealed class CategoriesQuery : IQueryString
{
    public string? Search { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["search"] = Search
        };
    }
}
