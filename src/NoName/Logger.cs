using Serilog;
using System;

public static class Logger
{
    private static readonly ILogger _logger = new LoggerConfiguration()
        .WriteTo.Debug().CreateLogger();

    public static void Info(string message)
    {
        _logger.Information(message);
    }

    public static void Error(string message, Exception exception = null)
    {
        if (exception != null)
        {
            _logger.Error(message);
        }
        else
        {
            _logger.Error(exception.Message, message);
        }
    }
}
