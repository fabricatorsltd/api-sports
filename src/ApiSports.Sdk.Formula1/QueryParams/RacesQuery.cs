using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Formula1.QueryParams;

public sealed class RacesQuery : IQueryString
{
    public int? Id { get; init; }
    public string? Date { get; init; }
    public int? Next { get; init; }
    public int? Last { get; init; }
    public int? Competition { get; init; }
    public int? Circuit { get; init; }
    public int? Season { get; init; }
    public string? Type { get; init; }
    public string? Timezone { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["date"] = Date,
            ["next"] = Next?.ToString(),
            ["last"] = Last?.ToString(),
            ["competition"] = Competition?.ToString(),
            ["circuit"] = Circuit?.ToString(),
            ["season"] = Season?.ToString(),
            ["type"] = Type,
            ["timezone"] = Timezone
        };
    }
}
