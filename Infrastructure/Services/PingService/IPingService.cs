using DTO.Request;
using Infrastructure.Handlers;
using System;

namespace Infrastructure.Services.PingServiceNameSpace
{
    public interface IPingService
    {
        public void Ping(RequestDto requestDto);
        public event EventHandler<PingHandlerArgs> PingEvent;
    }
}