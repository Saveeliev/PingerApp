using DTO.Request;
using DTO.Response;
using Infrastructure.Handlers;
using Infrastructure.Services.RequestProviderNameSpace;
using System.Timers;

namespace Infrastructure.Services.PingService
{
    public class PingService : IPingService
    {
        public delegate void PingHandler(ResponseDto response);
        public event PingHandler PingEvent;
        private RequestDto _request;
        private ResponseDto _response;
        public void Ping(RequestDto requestDto)
        {
            _request = requestDto;

            PingEvent += LogResponseHandler.WriteResponseInConsole;
            PingEvent += LogResponseHandler.WriteResponseInFile;

            var timer = new Timer();
            timer.Interval = requestDto.DelayInMilliseconds;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var request = RequestProvider.GetRequestByProtocol(_request.ProtocolType);
            var response = request.GetResponse(_request).Result;

            if (_response == null || response.Status != _response.Status)
            {
                PingEvent?.Invoke(response);
                _response = response;
            }
        }
    }
}