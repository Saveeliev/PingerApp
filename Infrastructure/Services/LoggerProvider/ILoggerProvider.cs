using DTO.Enums;
using Infrastructure.Handlers.LogHandler;

namespace Infrastructure.Services.LoggerProvider
{
    public interface ILoggerProvider
    {
        public ILogger GetLogger(LogWay logWay);
    }
}