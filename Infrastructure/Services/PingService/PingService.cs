using DTO.Request;
using Infrastructure.Handlers;
using Infrastructure.Services.RequestProvider;
using Infrastructure.Services.TimerManagerNameSpace;
using System;

namespace Infrastructure.Services.PingService
{
    public class PingService : IPingService
    {
        private readonly IRequestProvider _requestProvider;
        public PingService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider ?? throw new ArgumentNullException(nameof(requestProvider));
        }

        public void Ping(RequestDto requestDto)
        {
            var timerManager = new TimerManager(_requestProvider);
            timerManager.PingEvent += LogResponseHandler.WriteResponse;
            timerManager.CreateTimer(requestDto);
        }
    }
}