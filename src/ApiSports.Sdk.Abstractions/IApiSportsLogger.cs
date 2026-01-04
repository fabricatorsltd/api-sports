namespace ApiSports.Sdk.Abstractions;

public interface IApiSportsLogger
{
    bool IsEnabled(ApiSportsLogLevel level);

    void Log(ApiSportsLogLevel level, string message, Exception? exception = null);
}
