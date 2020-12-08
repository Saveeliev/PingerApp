using DTO.Request;

namespace PingerApp.PingerManager
{
    public interface IPingerManager
    {
        public void StartPinger(RequestDto[] requests);
    }
}