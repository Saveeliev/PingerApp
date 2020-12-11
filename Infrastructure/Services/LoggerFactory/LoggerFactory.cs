using System;
using DTO.Enums;
using Infrastructure.Handlers.LogHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.LoggerFactory
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public LoggerFactory(IServiceProvider serviceProvider, ILogger<LoggerFactory> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public ILogHandler GetLogger(LogWay logWay)
        {
            switch(logWay)
            {
                case LogWay.Console: return (LogToConsole)_serviceProvider.GetRequiredService(typeof(LogToConsole));
                case LogWay.File: return (LogToFile) _serviceProvider.GetRequiredService(typeof(LogToFile));
                default:
                    var exceptionMessage = "No logger exists for this log way";
                    _logger.LogError(exceptionMessage);
                    throw new Exception(exceptionMessage);
            }
        }
    }
}