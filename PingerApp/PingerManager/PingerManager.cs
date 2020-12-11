using System;
using DTO.Request;
using Infrastructure.Services.LogService;
using Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PingerApp.PingerManager
{
    public class PingerManager : IPingerManager
    {
        private readonly ILogService _logService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PingerManager> _logger;

        public PingerManager(ILogService logService, IServiceProvider serviceProvider, ILogger<PingerManager> logger)
        {
            _logService = logService ?? throw new ArgumentNullException(nameof(logService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void StartPinger(RequestDto[] requests)
        {
            var validator = (HostValidator)_serviceProvider.GetRequiredService(typeof(HostValidator));

            foreach (var request in requests)
            {
                var result = validator.Validate(request);

                if (result.IsValid)
                {
                    _logService.Log(request);
                }
                else
                {
                    _logger.LogError(result.ToString());
                    throw new Exception(result.ToString());
                }
            }
        }
    }
}