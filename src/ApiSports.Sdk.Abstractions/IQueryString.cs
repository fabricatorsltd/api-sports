namespace ApiSports.Sdk.Abstractions;

public interface IQueryString
{
    IReadOnlyDictionary<string, string?> ToQueryParameters();
}

