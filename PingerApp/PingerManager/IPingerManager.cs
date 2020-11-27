using DTO.Request;
using System.Collections.Generic;

namespace PingerApp.Pinger
{
    public interface IPingerManager
    {
        public void StartPinger(RequestDto[] requests);
    }
}