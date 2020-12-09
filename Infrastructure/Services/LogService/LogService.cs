using DTO.Request;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System;
using Infrastructure.Services.LoggerFactory;
using Infrastructure.Services.PingService;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly LogOptions _options;

        public LogService(IServiceProvider serviceProvider, IOptions<LogOptions> options, ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public void Log(RequestDto requestDto)
        {
            var pingService = (PingService.PingService)_serviceProvider.GetRequiredService(typeof(IPingService));

            var logWays = _options.LogWays;

            foreach (var logWay in logWays)
            {
                var logger = _loggerFactory.GetLogger(logWay);
                pingService.PingEvent += logger.LogHandler;
            }

            pingService.Ping(requestDto);
        }
    }
}