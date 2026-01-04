using System.Collections.Concurrent;
using ApiSports.Sdk.Abstractions;
using ApiSports.Sdk.Abstractions.Models.Common;

namespace ApiSports.Sdk.Core;

internal sealed class ApiSportsPacingRateLimiter(
    RateLimitOptions options,
    IApiSportsStatusClient statusClient,
    IApiSportsLogger? logger = null) : IApiSportsRateLimiter
{
    private readonly RateLimitOptions _options = options ?? throw new ArgumentNullException(nameof(options));
    private readonly IApiSportsStatusClient _statusClient = statusClient ?? throw new ArgumentNullException(nameof(statusClient));
    private readonly IApiSportsLogger _logger = logger ?? NullApiSportsLogger.Instance;
    private readonly ConcurrentDictionary<string, RateLimiterState> _states = new();
    private readonly ConcurrentDictionary<string, ResolutionState> _resolutions = new();

    public async Task WaitAsync(ApiSportsRequestContext context, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(context);

        int requestsPerMinute = await ResolveRequestsPerMinuteAsync(context, ct).ConfigureAwait(false);

        if (requestsPerMinute <= 0)
        {
            throw new InvalidOperationException("Requests per minute must be greater than zero.");
        }

        TimeSpan interval = ComputeInterval(requestsPerMinute);
        string key = GetKey(context);
        RateLimiterState state = _states.GetOrAdd(key, _ => new RateLimiterState());

        long delayTicks = ScheduleDelayTicks(state, interval);
        if (delayTicks > 0)
        {
            await Task.Delay(TimeSpan.FromTicks(delayTicks), ct).ConfigureAwait(false);
        }
    }

    private async Task<int> ResolveRequestsPerMinuteAsync(ApiSportsRequestContext context, CancellationToken ct)
    {
        if (_options.ResolutionMode == RateLimitResolutionMode.Custom)
        {
            int custom = _options.CustomRequestsPerMinute
                ?? throw new InvalidOperationException("CustomRequestsPerMinute must be set when using Custom resolution.");

            if (custom <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_options.CustomRequestsPerMinute), "CustomRequestsPerMinute must be greater than zero.");
            }

            return custom;
        }

        return await ResolveFromStatusAsync(context, ct).ConfigureAwait(false);
    }

    private async Task<int> ResolveFromStatusAsync(ApiSportsRequestContext context, CancellationToken ct)
    {
        string key = GetKey(context);
        ResolutionState state = _resolutions.GetOrAdd(key, _ => new ResolutionState());

        DateTimeOffset nowUtc = DateTimeOffset.UtcNow;
        RateLimitResolution? cached = state.Resolution;
        if (cached is not null && !IsExpired(cached, nowUtc))
        {
            return cached.RequestsPerMinute;
        }

        await state.Gate.WaitAsync(ct).ConfigureAwait(false);
        try
        {
            cached = state.Resolution;
            if (cached is not null && !IsExpired(cached, nowUtc))
            {
                return cached.RequestsPerMinute;
            }

            StatusResponse? status = null;
            try
            {
                status = await _statusClient.GetStatusAsync(ct).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                LogFallback("Status request failed. Falling back to conservative rate limit.", ex);
            }

            int resolved = ResolvePlanRate(status);
            state.Resolution = new RateLimitResolution(resolved, GetExpiration(nowUtc));
            return resolved;
        }
        finally
        {
            state.Gate.Release();
        }
    }

    private int ResolvePlanRate(StatusResponse? status)
    {
        string? plan = status?.Subscription?.Plan;
        if (string.IsNullOrWhiteSpace(plan))
        {
            LogFallback("Status plan missing. Falling back to conservative rate limit.", null);
            return _options.FallbackRequestsPerMinute;
        }

        if (plan.Equals("Free", StringComparison.OrdinalIgnoreCase))
        {
            return 10;
        }

        if (plan.Equals("Pro", StringComparison.OrdinalIgnoreCase))
        {
            return 300;
        }

        if (plan.Equals("Ultra", StringComparison.OrdinalIgnoreCase))
        {
            return 450;
        }

        if (plan.Equals("Mega", StringComparison.OrdinalIgnoreCase))
        {
            return 900;
        }

        if (plan.Equals("Custom", StringComparison.OrdinalIgnoreCase))
        {
            return 1200;
        }

        LogFallback($"Unknown plan '{plan}'. Falling back to conservative rate limit.", null);
        return _options.FallbackRequestsPerMinute;
    }

    private DateTimeOffset? GetExpiration(DateTimeOffset nowUtc)
    {
        TimeSpan? cacheDuration = _options.StatusCacheDuration;
        if (!cacheDuration.HasValue)
        {
            return null;
        }

        if (cacheDuration.Value <= TimeSpan.Zero)
        {
            return nowUtc;
        }

        return nowUtc.Add(cacheDuration.Value);
    }

    private bool IsExpired(RateLimitResolution resolution, DateTimeOffset nowUtc)
    {
        if (!resolution.ExpiresAt.HasValue)
        {
            return false;
        }

        return nowUtc >= resolution.ExpiresAt.Value;
    }

    private void LogFallback(string message, Exception? exception)
    {
        if (_logger.IsEnabled(ApiSportsLogLevel.Warning))
        {
            _logger.Log(ApiSportsLogLevel.Warning, message, exception);
        }
    }

    private static TimeSpan ComputeInterval(int requestsPerMinute)
    {
        double intervalTicks = TimeSpan.FromMinutes(1).Ticks / (double)requestsPerMinute;
        long ticks = (long)Math.Ceiling(intervalTicks);
        if (ticks < 1)
        {
            ticks = 1;
        }

        return TimeSpan.FromTicks(ticks);
    }

    private static long ScheduleDelayTicks(RateLimiterState state, TimeSpan interval)
    {
        long nowTicks = DateTimeOffset.UtcNow.UtcTicks;
        long scheduledTicks;

        lock (state.Sync)
        {
            long nextAllowed = state.NextAllowedTicks;
            scheduledTicks = nowTicks > nextAllowed ? nowTicks : nextAllowed;
            state.NextAllowedTicks = scheduledTicks + interval.Ticks;
        }

        long delayTicks = scheduledTicks - nowTicks;
        return delayTicks <= 0 ? 0 : delayTicks;
    }

    private static string GetKey(ApiSportsRequestContext context)
    {
        return $"{context.Host}|{context.Sport}";
    }

    private sealed class RateLimiterState
    {
        public object Sync { get; } = new();

        public long NextAllowedTicks;
    }

    private sealed class ResolutionState
    {
        public SemaphoreSlim Gate { get; } = new(1, 1);

        public RateLimitResolution? Resolution;
    }

    private sealed record RateLimitResolution(int RequestsPerMinute, DateTimeOffset? ExpiresAt);
}
