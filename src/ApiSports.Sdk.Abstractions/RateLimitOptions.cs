namespace ApiSports.Sdk.Abstractions;

public sealed class RateLimitOptions
{
    /// <summary>
    /// Se true, il client prova a non superare i limiti usando le info lette dagli header.
    /// </summary>
    public bool EnableClientSideThrottling { get; init; } = true;

    /// <summary>
    /// Quando remaining è 0, quanto attendere prima di riprovare (best-effort).
    /// </summary>
    public TimeSpan DefaultWaitWhenExhausted { get; init; } = TimeSpan.FromSeconds(1);

    /// <summary>
    /// Se arriva un 429, tenta 1 retry dopo il delay calcolato.
    /// </summary>
    public bool RetryOn429Once { get; init; } = true;

    public TimeSpan DefaultRetryDelayOn429 { get; init; } = TimeSpan.FromSeconds(1);
}