using DTO;
using DTO.Request;
using DTO.Response;
using Infrastructure.Services.RequestProvider;
using System;
using System.Timers;

namespace Infrastructure.Services.TimerManagerNameSpace
{
    public class TimerManager : ITimerManager
    {
        public delegate void PingHandler(ResponseDto response);
        public event PingHandler PingEvent;
        private RequestDto _request;
        private ResponseDto _response;

        private readonly IRequestProvider _requestProvider;

        public TimerManager(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider ?? throw new ArgumentNullException(nameof(requestProvider));
        }

        public void CreateTimer(RequestDto requestDto)
        {
            _request = requestDto;

            var timer = new Timer();
            timer.Interval = requestDto.Delay;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var request = _requestProvider.GetRequestByProtocol(_request.ProtocolType);
            var response = request.GetResponse(_request);

            if(_response == null || response.Status != _response.Status)
            {
                PingEvent?.Invoke(response);
                _response = response;
            }
        }
    }
}