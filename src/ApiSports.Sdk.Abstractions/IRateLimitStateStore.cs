namespace ApiSports.Sdk.Abstractions;

public interface IRateLimitStateStore
{
    ValueTask<RateLimitSnapshot?> GetAsync(RateLimitScope scope, CancellationToken ct);

    ValueTask SetAsync(RateLimitScope scope, RateLimitSnapshot snapshot, CancellationToken ct);
}
