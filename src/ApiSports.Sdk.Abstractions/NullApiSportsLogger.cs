namespace ApiSports.Sdk.Abstractions;

public sealed class NullApiSportsLogger : IApiSportsLogger
{
    public static NullApiSportsLogger Instance { get; } = new();

    private NullApiSportsLogger()
    {
    }

    public bool IsEnabled(ApiSportsLogLevel level)
    {
        return false;
    }

    public void Log(ApiSportsLogLevel level, string message, Exception? exception = null)
    {
    }
}
