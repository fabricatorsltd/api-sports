namespace ApiSports.Sdk.Abstractions;

public sealed record ApiSportsRequestContext(string Host, ApiSportsSport Sport)
{
    public string? EndpointGroup { get; init; }

    public static ApiSportsRequestContext FromBaseUri(Uri baseUri, ApiSportsSport sport)
    {
        ArgumentNullException.ThrowIfNull(baseUri);

        string host = baseUri.IsDefaultPort
            ? $"{baseUri.Scheme}://{baseUri.Host}"
            : $"{baseUri.Scheme}://{baseUri.Host}:{baseUri.Port}";

        return new ApiSportsRequestContext(host, sport);
    }
}
