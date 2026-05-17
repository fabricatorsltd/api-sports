using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Nfl.QueryParams;

public sealed class GamesQuery : IQueryString
{
    public int? Id { get; init; }
    public DateOnly? Date { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }
    public int? Team { get; init; }
    public string? H2H { get; init; }
    public string? Live { get; init; }
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
            ["h2h"] = H2H,
            ["live"] = Live,
            ["timezone"] = Timezone
        };
    }
}

public sealed class GameEventsQuery : IQueryString
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

public sealed class GameTeamStatisticsQuery : IQueryString
{
    public required int Id { get; init; }
    public int? Team { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id.ToString(),
            ["team"] = Team?.ToString()
        };
    }
}

public sealed class GamePlayerStatisticsQuery : IQueryString
{
    public required int Id { get; init; }
    public string? Group { get; init; }
    public int? Team { get; init; }
    public int? Player { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["id"] = Id.ToString(),
            ["group"] = Group,
            ["team"] = Team?.ToString(),
            ["player"] = Player?.ToString()
        };
    }
}
