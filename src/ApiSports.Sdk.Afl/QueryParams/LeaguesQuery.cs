using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Afl.QueryParams;

public sealed class LeaguesQuery : IQueryString
{
    public int? Id { get; init; }
    public int? Season { get; init; }
    public bool? Current { get; init; }
    public string? Timezone { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["season"] = Season?.ToString(),
            ["current"] = Current?.ToString().ToLowerInvariant(),
            ["timezone"] = Timezone
        };
    }
}
