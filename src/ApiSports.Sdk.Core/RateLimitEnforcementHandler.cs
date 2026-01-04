using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

public sealed class RateLimitEnforcementHandler(
    IRateLimitStateStore store,
    RateLimitOptions options,
    RateLimitScope scope,
    IApiSportsRateLimiter? pacingLimiter = null,
    ApiSportsRequestContext? requestContext = null)
    : DelegatingHandler
{
    private readonly IApiSportsRateLimiter? _pacingLimiter = pacingLimiter;
    private readonly ApiSportsRequestContext? _requestContext = requestContext ?? (pacingLimiter is null ? null : throw new ArgumentNullException(nameof(requestContext)));

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (options.EnableClientSideThrottling)
        {
            RateLimitSnapshot? snapshot = await store.GetAsync(scope, cancellationToken).ConfigureAwait(false);
            TimeSpan? delay = ComputeDelay(snapshot);
            if (delay.HasValue && delay.Value > TimeSpan.Zero)
            {
                await Task.Delay(delay.Value, cancellationToken).ConfigureAwait(false);
            }
        }

        HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        if ((int)response.StatusCode == 429 && options.RetryOn429Once)
        {
            TimeSpan? retryAfter = TryGetRetryAfter(response) ?? options.DefaultRetryDelayOn429;
            if (retryAfter.HasValue && retryAfter.Value > TimeSpan.Zero)
            {
                response.Dispose();

                if (_pacingLimiter is not null && _requestContext is not null)
                {
                    _pacingLimiter.Report(_requestContext, response.StatusCode, retryAfter);
                    await _pacingLimiter.WaitAsync(_requestContext, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    await Task.Delay(retryAfter.Value, cancellationToken).ConfigureAwait(false);
                }

                HttpResponseMessage retryResponse = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return retryResponse;
            }
        }

        return response;
    }

    private TimeSpan? ComputeDelay(RateLimitSnapshot? snapshot)
    {
        if (snapshot is null)
        {
            return null;
        }

        bool minuteExhausted = snapshot.RemainingPerMinute.HasValue && snapshot.RemainingPerMinute.Value <= 0;
        bool dayExhausted = snapshot.RemainingPerDay.HasValue && snapshot.RemainingPerDay.Value <= 0;

        if (minuteExhausted || dayExhausted)
        {
            return options.DefaultWaitWhenExhausted;
        }

        return null;
    }

    private static TimeSpan? TryGetRetryAfter(HttpResponseMessage response)
    {
        if (response.Headers.TryGetValues(ApiSportsHeaderNames.RetryAfter, out IEnumerable<string>? values))
        {
            string? first = values.FirstOrDefault();
            if (first is not null && int.TryParse(first, out int seconds) && seconds > 0)
            {
                return TimeSpan.FromSeconds(seconds);
            }
        }

        return null;
    }
}
