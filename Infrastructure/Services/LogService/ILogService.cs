using DTO.Request;

namespace Infrastructure.Services.LogService
{
    public interface ILogService
    {
        public void Log(RequestDto requestDto);
    }
}
