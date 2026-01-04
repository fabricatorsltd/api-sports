using System.Diagnostics;
using System.Net;
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
            CustomRequestsPerMinute = 600
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

        TimeSpan interval = TimeSpan.FromMilliseconds(100);
        TimeSpan tolerance = TimeSpan.FromMilliseconds(50);

        Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(1), "Keys did not progress independently.");

        foreach (DateTimeOffset[] result in results)
        {
            TimeSpan delta = result[1] - result[0];
            Assert.True(delta >= interval - tolerance, $"Delta {delta} was below expected interval.");
        }
    }

    [Fact]
    public async Task WaitAsync_WarmsUpOnFirstUse()
    {
        RateLimitOptions options = new()
        {
            ResolutionMode = RateLimitResolutionMode.Custom,
            CustomRequestsPerMinute = 60
        };

        ApiSportsPacingRateLimiter limiter = new(options, new StubStatusClient());
        ApiSportsRequestContext context = ApiSportsRequestContext.FromBaseUri(
            new Uri("https://v3.football.api-sports.io/"),
            ApiSportsSport.Football);

        Stopwatch stopwatch = Stopwatch.StartNew();
        await limiter.WaitAsync(context, CancellationToken.None);
        stopwatch.Stop();

        TimeSpan interval = TimeSpan.FromSeconds(1);
        TimeSpan tolerance = TimeSpan.FromMilliseconds(150);

        Assert.True(stopwatch.Elapsed >= interval - tolerance, $"Warm-up delay {stopwatch.Elapsed} was below expected interval.");
    }

    [Fact]
    public void ComputeEffectiveRequestsPerMinute_AppliesSafetyFactor()
    {
        int effective = ApiSportsPacingRateLimiter.ComputeEffectiveRequestsPerMinute(60, 0.85);
        Assert.Equal(51, effective);

        int minimum = ApiSportsPacingRateLimiter.ComputeEffectiveRequestsPerMinute(1, 0.1);
        Assert.Equal(1, minimum);
    }

    [Fact]
    public async Task Report_429AppliesPenalty()
    {
        RateLimitOptions options = new()
        {
            ResolutionMode = RateLimitResolutionMode.Custom,
            CustomRequestsPerMinute = 600,
            PenaltyDuration = TimeSpan.FromMilliseconds(200)
        };

        ApiSportsPacingRateLimiter limiter = new(options, new StubStatusClient());
        ApiSportsRequestContext context = ApiSportsRequestContext.FromBaseUri(
            new Uri("https://v3.football.api-sports.io/"),
            ApiSportsSport.Football);

        await limiter.WaitAsync(context, CancellationToken.None);

        limiter.Report(context, HttpStatusCode.TooManyRequests, null);

        Stopwatch stopwatch = Stopwatch.StartNew();
        await limiter.WaitAsync(context, CancellationToken.None);
        stopwatch.Stop();

        TimeSpan tolerance = TimeSpan.FromMilliseconds(50);
        Assert.True(stopwatch.Elapsed >= options.PenaltyDuration - tolerance, $"Penalty delay {stopwatch.Elapsed} was below expected minimum.");
    }

    private static async Task<DateTimeOffset[]> RunSequenceAsync(
        ApiSportsPacingRateLimiter limiter,
        ApiSportsRequestContext context,
        int count)
    {
        var results = new DateTimeOffset[count];
        for (int i = 0; i < count; i++)
        {
            await limiter.WaitAsync(context, CancellationToken.None);
            results[i] = DateTimeOffset.UtcNow;
        }

        return results;
    }

    private static async Task<DateTimeOffset> WaitAndStampAsync(
        ApiSportsPacingRateLimiter limiter,
        ApiSportsRequestContext context)
    {
        await limiter.WaitAsync(context, CancellationToken.None);
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
