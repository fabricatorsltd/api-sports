namespace ApiSports.Sdk.Abstractions;

public interface IApiSportsRateLimiter
{
    Task WaitAsync(ApiSportsRequestContext context, CancellationToken ct);
}
