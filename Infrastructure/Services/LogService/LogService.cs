using DTO.Request;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System;
using Infrastructure.Services.LoggerProvider;
using Infrastructure.Services.PingService;

namespace Infrastructure.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggerProvider _loggerProvider;
        private readonly LogOptions _options;

        public LogService(IServiceProvider serviceProvider, IOptions<LogOptions> options, ILoggerProvider loggerProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _loggerProvider = loggerProvider ?? throw new ArgumentNullException(nameof(loggerProvider));
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public void Log(RequestDto requestDto)
        {
            var service = _serviceProvider.GetService(typeof(IPingService));
            var pingService = (PingService.PingService)service;

            var logWays = _options.LogWays;

            foreach (var logWay in logWays)
            {
                var logger = _loggerProvider.GetLogger(logWay);
                pingService.PingEvent += logger.LogHandler;
            }

            pingService.Ping(requestDto);
        }
    }
}