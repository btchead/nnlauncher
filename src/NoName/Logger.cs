using Serilog;
using System;

namespace NoName
{
    public static class Logger
    {
        private static readonly ILogger _logger = new LoggerConfiguration()
            .WriteTo.Debug().CreateLogger();

        public static void Info(string message)
        {
            _logger.Information(message);
        }

        public static void Error(string message, Exception exception)
        {
            _logger.Error(message);
        }
    }
}
