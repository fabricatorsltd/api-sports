using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class TeamsStatisticsQuery : IQueryString
{
    public required int Team { get; init; }
    public required int League { get; init; }
    public required int Season { get; init; }
    public DateOnly? Date { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["team"] = Team.ToString(),
            ["league"] = League.ToString(),
            ["season"] = Season.ToString(),
            ["date"] = Date?.ToString("yyyy-MM-dd")
        };
    }
}
