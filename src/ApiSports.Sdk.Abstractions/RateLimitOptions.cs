namespace ApiSports.Sdk.Abstractions;

public sealed class RateLimitOptions
{
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
