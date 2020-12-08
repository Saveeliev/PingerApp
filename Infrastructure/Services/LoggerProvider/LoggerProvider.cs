using DTO.Enums;
using Infrastructure.Handlers.LogHandler;
using Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.LoggerProvider
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly IOptions<LogOptions> _options;

        public LoggerProvider(IOptions<LogOptions> options)
        {
            _options = options ?? throw new System.ArgumentNullException(nameof(options));
        }
        public ILogger GetLogger(LogWay logWay)
        {
            switch(logWay)
            {
                case LogWay.Console: return new LogToConsole();
                case LogWay.File: return new LogToFile(_options);
            }

            return null;
        }
    }
}