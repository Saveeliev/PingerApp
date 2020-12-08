using System;
using DTO.Request;
using Infrastructure.Handlers;

namespace Infrastructure.Services.PingService
{
    public interface IPingService
    {
        public void Ping(RequestDto requestDto);
        public event EventHandler<PingHandlerArgs> PingEvent;
    }
}