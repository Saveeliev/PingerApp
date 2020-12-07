using DTO.Request;
using Infrastructure.Services.LogService;
using Infrastructure.Validation;
using System;

namespace PingerApp.Pinger
{
    public class PingerManager : IPingerManager
    {
        private readonly ILogService _logService;

        public PingerManager(ILogService logService)
        {
            _logService = logService ?? throw new ArgumentNullException(nameof(logService));
        }
        public void StartPinger(RequestDto[] requests)
        {
            var validator = new HostValidatior();

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