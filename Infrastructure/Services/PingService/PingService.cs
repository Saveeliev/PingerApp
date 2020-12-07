using DTO.Request;
using DTO.Response;
using Infrastructure.Handlers;
using Infrastructure.Services.RequestProviderNameSpace;
using System;
using System.Timers;

namespace Infrastructure.Services.PingServiceNameSpace
{
    public class PingService : IPingService, IDisposable
    {
        public event EventHandler<PingHandlerArgs> PingEvent;
        private RequestDto _request;
        private ResponseDto _response;
        public void Ping(RequestDto requestDto)
        {
            _request = requestDto;

            var timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = requestDto.DelayInMilliseconds;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var request = RequestProvider.GetRequestByProtocol(_request.ProtocolType);
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
        }
    }
}