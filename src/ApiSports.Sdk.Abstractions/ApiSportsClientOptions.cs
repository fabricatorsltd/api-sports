namespace ApiSports.Sdk.Abstractions;

public sealed class ApiSportsClientOptions
{
    public required string ApiKey { get; init; }

    public Uri BaseUri { get; init; } = new Uri("https://v3.football.api-sports.io/");
    
    public TimeSpan Timeout { get; init; } = TimeSpan.FromSeconds(30);

    public RateLimitOptions RateLimit { get; init; } = new RateLimitOptions();
}