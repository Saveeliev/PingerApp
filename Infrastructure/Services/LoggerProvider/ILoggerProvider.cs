using DTO.Enums;
using Infrastructure.Handlers.LogHandler;

namespace Infrastructure.Services.LoggerProviderNameSpace
{
    public interface ILoggerProvider
    {
        public ILogger GetLogger(LogWay logWay);
    }
}