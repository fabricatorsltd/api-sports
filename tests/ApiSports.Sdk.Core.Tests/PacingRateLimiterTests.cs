using System.Diagnostics;
using ApiSports.Sdk.Abstractions;
using Xunit;

namespace ApiSports.Sdk.Core.Tests;

public sealed class PacingRateLimiterTests
{
    [Fact]
    public async Task WaitAsync_SchedulesNonDecreasingIntervals()
    {
        RateLimitOptions options = new()
        {
            ResolutionMode = RateLimitResolutionMode.Custom,
            CustomRequestsPerMinute = 60
        };

        ApiSportsPacingRateLimiter limiter = new(options, new StubStatusClient());
        var context = ApiSportsRequestContext.FromBaseUri(
            new Uri("https://v3.football.api-sports.io/"),
            ApiSportsSport.Football);

        int calls = 3;
        var tasks = new Task<DateTimeOffset>[calls];

        for (int i = 0; i < calls; i++)
        {
            tasks[i] = WaitAndStampAsync(limiter, context);
        }

        DateTimeOffset[] timestamps = await Task.WhenAll(tasks);
        Array.Sort(timestamps);

        var interval = TimeSpan.FromSeconds(1);
        var tolerance = TimeSpan.FromMilliseconds(100);

        for (int i = 1; i < timestamps.Length; i++)
        {
            TimeSpan delta = timestamps[i] - timestamps[i - 1];
            Assert.True(delta >= interval - tolerance, $"Delta {delta} was below expected interval.");
        }

        TimeSpan totalElapsed = timestamps[^1] - timestamps[0];
        TimeSpan expectedMinimum = TimeSpan.FromTicks((calls - 1) * interval.Ticks) - tolerance;
        Assert.True(totalElapsed >= expectedMinimum, $"Elapsed {totalElapsed} was below expected minimum.");
    }

    [Fact]
    public async Task WaitAsync_IsIndependentPerKey()
    {
        RateLimitOptions options = new()
        {
            ResolutionMode = RateLimitResolutionMode.Custom,
            CustomRequestsPerMinute = 60
        };

        ApiSportsPacingRateLimiter limiter = new(options, new StubStatusClient());
        var contextA = ApiSportsRequestContext.FromBaseUri(
            new Uri("https://v3.football.api-sports.io/"),
            ApiSportsSport.Football);
        var contextB = ApiSportsRequestContext.FromBaseUri(
            new Uri("https://v1.basketball.api-sports.io/"),
            ApiSportsSport.Basketball);

        var stopwatch = Stopwatch.StartNew();
        Task<DateTimeOffset[]> sequenceA = RunSequenceAsync(limiter, contextA, 2);
        Task<DateTimeOffset[]> sequenceB = RunSequenceAsync(limiter, contextB, 2);

        DateTimeOffset[][] results = await Task.WhenAll(sequenceA, sequenceB);
        stopwatch.Stop();

        var interval = TimeSpan.FromSeconds(1);
        var tolerance = TimeSpan.FromMilliseconds(150);

        Assert.True(stopwatch.Elapsed < interval + TimeSpan.FromSeconds(1), "Keys did not progress independently.");

        foreach (DateTimeOffset[] result in results)
        {
            TimeSpan delta = result[1] - result[0];
            Assert.True(delta >= interval - tolerance, $"Delta {delta} was below expected interval.");
        }
    }

    private static async Task<DateTimeOffset[]> RunSequenceAsync(
        ApiSportsPacingRateLimiter limiter,
        ApiSportsRequestContext context,
        int count)
    {
        var results = new DateTimeOffset[count];
        for (int i = 0; i < count; i++)
        {
            await limiter.WaitAsync(context, CancellationToken.None).ConfigureAwait(false);
            results[i] = DateTimeOffset.UtcNow;
        }

        return results;
    }

    private static async Task<DateTimeOffset> WaitAndStampAsync(
        ApiSportsPacingRateLimiter limiter,
        ApiSportsRequestContext context)
    {
        await limiter.WaitAsync(context, CancellationToken.None).ConfigureAwait(false);
        return DateTimeOffset.UtcNow;
    }

    private sealed class StubStatusClient : IApiSportsStatusClient
    {
        public Task<Abstractions.Models.Common.StatusResponse?> GetStatusAsync(CancellationToken ct)
        {
            return Task.FromResult<Abstractions.Models.Common.StatusResponse?>(null);
        }
    }
}
