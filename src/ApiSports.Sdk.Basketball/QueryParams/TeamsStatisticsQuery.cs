using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Basketball.QueryParams;

public sealed class TeamsStatisticsQuery : IQueryString
{
    public required int League { get; init; }
    public required string Season { get; init; }
    public required int Team { get; init; }
    public DateOnly? Date { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["league"] = League.ToString(),
            ["season"] = Season,
            ["team"] = Team.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd")
        };
    }
}
