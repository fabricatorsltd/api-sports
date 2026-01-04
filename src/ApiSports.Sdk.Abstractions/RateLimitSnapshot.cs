namespace ApiSports.Sdk.Abstractions;

public sealed record RateLimitSnapshot(
    DateTimeOffset UpdatedAtUtc,
    int? LimitPerMinute,
    int? RemainingPerMinute,
    int? LimitPerDay,
    int? RemainingPerDay
);