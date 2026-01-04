using System.Net;

namespace ApiSports.Sdk.Abstractions;

public interface IApiSportsRateLimiter
{
    Task WaitAsync(ApiSportsRequestContext context, CancellationToken ct);

    void Report(ApiSportsRequestContext context, HttpStatusCode statusCode, TimeSpan? retryAfter);
}
