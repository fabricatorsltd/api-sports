using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public class TeamsSeasonsQuery : IQueryString
{
    public required int Team { get; init; }
    
    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["team"] = Team.ToString(),
        };
    }
}
