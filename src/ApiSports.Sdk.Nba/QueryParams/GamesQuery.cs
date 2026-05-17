using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nba.QueryParams;

public sealed class GamesQuery : IQueryString
{
    public int? Id { get; init; }
    public DateOnly? Date { get; init; }
    public string? Live { get; init; }
    public string? League { get; init; }
    public int? Season { get; init; }
    public int? Team { get; init; }
    public string? H2H { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id?.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["live"] = Live,
            ["league"] = League,
            ["season"] = Season?.ToString(),
            ["team"] = Team?.ToString(),
            ["h2h"] = H2H
        };
    }
}

public sealed class GamesStatisticsQuery : IQueryString
{
    public required int Id { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id.ToString()
        };
    }
}
