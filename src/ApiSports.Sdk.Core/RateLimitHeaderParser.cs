using System.Net.Http.Headers;
using ApiSports.Sdk.Abstractions;

namespace ApiSports.Sdk.Core;

internal static class RateLimitHeaderParser
{
    public static RateLimitSnapshot? TryParse(HttpResponseHeaders headers, DateTimeOffset nowUtc)
    {
        int? limitPerMinute = TryGetInt(headers, ApiSportsHeaderNames.RateLimitLimitPerMinute);
        int? remainingPerMinute = TryGetInt(headers, ApiSportsHeaderNames.RateLimitRemainingPerMinute);

        int? limitPerDay = TryGetInt(headers, ApiSportsHeaderNames.RateLimitLimitPerDay);
        int? remainingPerDay = TryGetInt(headers, ApiSportsHeaderNames.RateLimitRemainingPerDay);

        bool hasAny =
            limitPerMinute.HasValue || remainingPerMinute.HasValue ||
            limitPerDay.HasValue || remainingPerDay.HasValue;

        if (!hasAny)
        {
            return null;
        }

        var snapshot = new RateLimitSnapshot(
            UpdatedAtUtc: nowUtc,
            LimitPerMinute: limitPerMinute,
            RemainingPerMinute: remainingPerMinute,
            LimitPerDay: limitPerDay,
            RemainingPerDay: remainingPerDay
        );

        return snapshot;
    }

    private static int? TryGetInt(HttpResponseHeaders headers, string name)
    {
        if (!headers.TryGetValues(name, out IEnumerable<string>? values))
        {
            return null;
        }

        string? first = values.FirstOrDefault();
        if (first is null)
        {
            return null;
        }

        if (int.TryParse(first, out int parsed))
        {
            return parsed;
        }

        return null;
    }
}