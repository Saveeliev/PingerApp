using Infrastructure.Helpers;
using System;

namespace Infrastructure.Handlers.LogHandler
{
    public class LogToConsole : ILogHandler
    {
        public void LogHandler(object sender, PingHandlerArgs eventArgs)
        {
            Console.WriteLine(LogHelper.GetLogString(eventArgs.ResponseDto));
        }
    }
}