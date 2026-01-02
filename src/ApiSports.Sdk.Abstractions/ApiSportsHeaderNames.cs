namespace ApiSports.Sdk.Abstractions;

public static class ApiSportsHeaderNames
{
    public const string ApiKey = "x-apisports-key";

    // per-minute
    public const string RateLimitLimitPerMinute = "X-RateLimit-Limit";
    public const string RateLimitRemainingPerMinute = "X-RateLimit-Remaining";

    // per-day
    public const string RateLimitLimitPerDay = "x-ratelimit-requests-limit";
    public const string RateLimitRemainingPerDay = "x-ratelimit-requests-remaining";

    public const string RetryAfter = "Retry-After";
}