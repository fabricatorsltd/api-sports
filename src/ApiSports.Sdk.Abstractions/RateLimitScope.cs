namespace ApiSports.Sdk.Abstractions;

public sealed record RateLimitScope(string Value)
{
    public static RateLimitScope FromBaseUri(Uri baseUri)
    {
        ArgumentNullException.ThrowIfNull(baseUri);

        string host = baseUri.IsDefaultPort
            ? $"{baseUri.Scheme}://{baseUri.Host}"
            : $"{baseUri.Scheme}://{baseUri.Host}:{baseUri.Port}";

        return new RateLimitScope(host);
    }

    public override string ToString() => Value;
}
