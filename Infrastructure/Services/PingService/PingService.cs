using System;
using System.Collections.Generic;
using System.Timers;
using DTO.Request;
using DTO.Response;
using Infrastructure.Handlers;
using Infrastructure.Services.RequestFactory;

namespace Infrastructure.Services.PingService
{
    public class PingService : IPingService, IDisposable
    {
        private readonly IRequestFactory _requestFactory;
        public event EventHandler<PingHandlerArgs> PingEvent;
        private RequestDto _request;
        private ResponseDto _response;
        private readonly List<Timer> _timers = new List<Timer>();

        public PingService(IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory ?? throw new ArgumentNullException(nameof(requestFactory));
        }
        
        public void Ping(RequestDto requestDto)
        {
            _request = requestDto;

            var timer = new Timer();
            timer.Elapsed += TimerHandler;
            timer.Interval = requestDto.DelayInMilliseconds;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();

            _timers.Add(timer);
        }

        private async void TimerHandler(object sender, ElapsedEventArgs e)
        {
            var request = _requestFactory.GetRequestByProtocol(_request.ProtocolType);
            var response = await request.GetResponseAsync(_request);

            if (_response == null || response.Status != _response.Status)
            {
                PingEvent?.Invoke(this, new PingHandlerArgs { ResponseDto = response });
                _response = response;
            }
        }

        public void Dispose()
        {
            PingEvent = null;

            if (_timers.Count == 0) return;
            foreach (var timer in _timers)
            {
                timer.Dispose();
            }
        }
    }
}