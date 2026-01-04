using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Football.QueryParams;

public sealed class PredictionsQuery : IQueryString
{
    public required int Fixture { get; init; }

    public IReadOnlyDictionary<string, string?> ToQueryParameters()
    {
        return new Dictionary<string, string?>
        {
            ["fixture"] = Fixture.ToString()
        };
    }
}
