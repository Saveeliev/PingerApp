using DTO.Request;
using Infrastructure.Services.PingService;
using Infrastructure.Validation;
using System;
using System.Collections.Generic;

namespace PingerApp.Pinger
{
    public class PingerManager : IPingerManager
    {
        private readonly IPingService _pingService;

        public PingerManager(IPingService pingService)
        {
            _pingService = pingService ?? throw new ArgumentNullException(nameof(pingService));
        }
        public void StartPinger(RequestDto[] requests)
        {
            var validator = new HostValidatior();

            foreach (var request in requests)
            {
                var result = validator.Validate(request);

                if (result.IsValid)
                {
                    _pingService.Ping(request);
                }
                else
                {
                    throw new Exception(result.ToString());
                }
            }
        }
    }
}