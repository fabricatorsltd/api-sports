using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Afl.QueryParams;

public sealed class GamesQuery : IQueryString
{
    public int? Id { get; init; }
    public DateOnly? Date { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }
    public int? Team { get; init; }
    public string? Timezone { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["team"] = Team?.ToString(),
            ["timezone"] = Timezone
        };
    }
}
