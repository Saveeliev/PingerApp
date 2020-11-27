using DTO.Request;
using static Infrastructure.Services.PingService.PingService;

namespace Infrastructure.Services.PingService
{
    public interface IPingService
    {
        public void Ping(RequestDto requestDto);
    }
}