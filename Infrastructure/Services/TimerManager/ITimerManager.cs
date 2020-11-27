using DTO.Request;
using static Infrastructure.Services.TimerManagerNameSpace.TimerManager;

namespace Infrastructure.Services.TimerManagerNameSpace
{
    public interface ITimerManager
    {
        public void CreateTimer(RequestDto request);
        public event PingHandler PingEvent;
    }
}