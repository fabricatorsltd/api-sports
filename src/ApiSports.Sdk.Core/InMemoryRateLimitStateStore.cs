using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class InMemoryRateLimitStateStore : IRateLimitStateStore
{
    private readonly object _gate = new();
    private readonly Dictionary<RateLimitScope, RateLimitSnapshot> _map = new();

    public ValueTask<RateLimitSnapshot?> GetAsync(RateLimitScope scope, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        RateLimitSnapshot? snapshot;
        lock (_gate)
        {
            _map.TryGetValue(scope, out snapshot);
        }

        return ValueTask.FromResult(snapshot);
    }

    public ValueTask SetAsync(RateLimitScope scope, RateLimitSnapshot snapshot, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        lock (_gate)
        {
            _map[scope] = snapshot;
        }

        return ValueTask.CompletedTask;
    }
}
