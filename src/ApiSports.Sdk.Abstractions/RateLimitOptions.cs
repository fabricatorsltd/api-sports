namespace ApiSports.Sdk.Abstractions;

public sealed class RateLimitOptions
{
    /// <summary>
    /// Determines how the requests-per-minute limit is resolved.
    /// </summary>
    public RateLimitResolutionMode ResolutionMode { get; set; } = RateLimitResolutionMode.AutoFromStatus;

    /// <summary>
    /// When <see cref="ResolutionMode"/> is <see cref="RateLimitResolutionMode.Custom"/>,
    /// specifies the requests per minute to enforce.
    /// </summary>
    public int? CustomRequestsPerMinute { get; set; }

    /// <summary>
    /// When status resolution fails or returns an unknown plan, use this conservative fallback.
    /// </summary>
    public int FallbackRequestsPerMinute { get; set; } = 10;

    /// <summary>
    /// Optional cache duration for the resolved status plan. When null, cache for the lifetime of the client.
    /// </summary>
    public TimeSpan? StatusCacheDuration { get; set; }

    /// <summary>
    /// Safety factor applied to the base requests-per-minute before pacing.
    /// </summary>
    public double SafetyFactor { get; set; } = 0.85;

    /// <summary>
    /// Default penalty applied when receiving a 429 response.
    /// </summary>
    public TimeSpan PenaltyDuration { get; set; } = TimeSpan.FromSeconds(60);

    /// <summary>
    /// Maximum penalty to apply when honoring Retry-After.
    /// </summary>
    public TimeSpan RetryAfterPenaltyCap { get; set; } = TimeSpan.FromMinutes(2);

    /// <summary>
    /// If true, the client tries to not exceed the limits using the info read from the headers.
    /// </summary>
    public bool EnableClientSideThrottling { get; set; } = true;

    /// <summary>
    /// When remaining is 0, how long to wait before retrying (best-effort).
    /// </summary>
    public TimeSpan DefaultWaitWhenExhausted { get; set; } = TimeSpan.FromSeconds(5);

    /// <summary>
    /// If true, when receiving a 429 response, the client will retry once after a delay.
    /// </summary>
    public bool RetryOn429Once { get; set; } = true;

    public TimeSpan DefaultRetryDelayOn429 { get; set; } = TimeSpan.FromSeconds(15);
}
