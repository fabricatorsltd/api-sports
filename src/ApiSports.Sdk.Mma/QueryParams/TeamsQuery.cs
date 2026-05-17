using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Mma.QueryParams;

public sealed class TeamsQuery : IQueryString
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
