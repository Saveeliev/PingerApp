using System;
using DTO.Request;
using Infrastructure.Services.LogService;
using Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace PingerApp.PingerManager
{
    public class PingerManager : IPingerManager
    {
        private readonly ILogService _logService;
        private readonly IServiceProvider _serviceProvider;

        public PingerManager(ILogService logService, IServiceProvider serviceProvider)
        {
            _logService = logService ?? throw new ArgumentNullException(nameof(logService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
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
                    throw new Exception(result.ToString());
                }
            }
        }
    }
}