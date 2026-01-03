using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class InjuriesQuery : IQueryString
{
    public int? League { get; init; }
    public int? Season { get; init; }
    public string? Fixture { get; init; }
    public int? Team { get; init; }
    public string? Player { get; init; }
    public DateOnly? Date { get; init; }
    public string? Timezone { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["fixture"] = Fixture,
            ["team"] = Team?.ToString(),
            ["player"] = Player,
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["timezone"] = Timezone
        };
    }
}
