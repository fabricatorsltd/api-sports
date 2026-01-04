using ApiSports.Sdk.Abstractions;
using Microsoft.Extensions.Logging;

namespace ApiSports.Sdk.Logging.Microsoft;

public sealed class MicrosoftLoggerAdapter(ILogger logger) : IApiSportsLogger
{
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public bool IsEnabled(ApiSportsLogLevel level)
    {
        return _logger.IsEnabled(MapLevel(level));
    }

    public void Log(ApiSportsLogLevel level, string message, Exception? exception = null)
    {
        switch (level)
        {
            case ApiSportsLogLevel.Debug:
                if (exception is null)
                {
                    _logger.LogDebug(message);
                }
                else
                {
                    _logger.LogDebug(exception, message);
                }

                break;
            case ApiSportsLogLevel.Information:
                if (exception is null)
                {
                    _logger.LogInformation(message);
                }
                else
                {
                    _logger.LogInformation(exception, message);
                }

                break;
            case ApiSportsLogLevel.Warning:
                if (exception is null)
                {
                    _logger.LogWarning(message);
                }
                else
                {
                    _logger.LogWarning(exception, message);
                }

                break;
            case ApiSportsLogLevel.Error:
                if (exception is null)
                {
                    _logger.LogError(message);
                }
                else
                {
                    _logger.LogError(exception, message);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(level), level, null);
        }
    }

    private static LogLevel MapLevel(ApiSportsLogLevel level)
    {
        return level switch
        {
            ApiSportsLogLevel.Debug => LogLevel.Debug,
            ApiSportsLogLevel.Information => LogLevel.Information,
            ApiSportsLogLevel.Warning => LogLevel.Warning,
            ApiSportsLogLevel.Error => LogLevel.Error,
            _ => LogLevel.None
        };
    }
}
