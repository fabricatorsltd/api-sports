using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class FixturesHeadToHeadQuery : IQueryString
{
    public required string H2H { get; init; }
    public DateOnly? Date { get; init; }
    public int? League { get; init; }
    public int? Season { get; init; }

    public int? Last { get; init; }
    public int? Next { get; init; }

    public DateOnly? From { get; init; }
    public DateOnly? To { get; init; }

    public string? Status { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["h2h"] = H2H,
            ["date"] = Date?.ToString("yyyy-MM-dd"),
            ["league"] = League?.ToString(),
            ["season"] = Season?.ToString(),
            ["last"] = Last?.ToString(),
            ["next"] = Next?.ToString(),
            ["from"] = From?.ToString("yyyy-MM-dd"),
            ["to"] = To?.ToString("yyyy-MM-dd"),
            ["status"] = Status,
        };
    }
}

