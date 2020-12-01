using DTO.Request;
using Infrastructure.Services.PingService;
using Infrastructure.Validation;
using System;
using System.Collections.Generic;

namespace PingerApp.Pinger
{
    public class PingerManager : IPingerManager
    {
        private readonly IServiceProvider _serviceProvider;

        public PingerManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        public void StartPinger(RequestDto[] requests)
        {
            var validator = new HostValidatior();

            foreach (var request in requests)
            {
                var result = validator.Validate(request);

                if (result.IsValid)
                {
                    var service = _serviceProvider.GetService(typeof(IPingService));
                    var pingService = (PingService)service;
                    pingService.Ping(request);
                }
                else
                {
                    throw new Exception(result.ToString());
                }
            }
        }
    }
}