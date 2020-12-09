using System;
using DTO.Enums;
using Infrastructure.Handlers.LogHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services.LoggerFactory
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LoggerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        public ILogger GetLogger(LogWay logWay)
        {
            switch(logWay)
            {
                case LogWay.Console: return (LogToConsole)_serviceProvider.GetRequiredService(typeof(LogToConsole));
                case LogWay.File: return (LogToFile)_serviceProvider.GetRequiredService(typeof(LogToFile));
                default: throw new Exception("No logger exists for this log way");
            }
        }
    }
}