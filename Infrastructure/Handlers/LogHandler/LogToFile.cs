using Infrastructure.Helpers;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.IO;
using System.Text;

namespace Infrastructure.Handlers.LogHandler
{
    public class LogToFile : ILogger
    {
        private static object _locker = 0;
        private readonly LogOptions _options;

        public LogToFile(IOptions<LogOptions> options)
        {
            _options = options.Value;
        }

        public void LogHandler(object sender, PingHandlerArgs eventArgs)
        {
            var path = _options.PathToLogFile;

            lock (_locker)
            {
                using var stream = new FileStream(path, FileMode.OpenOrCreate);

                stream.Seek(0, SeekOrigin.End);

                var bytes = Encoding.Default.GetBytes(LogHelper.GetLogString(eventArgs.ResponseDto) + "\n");

                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}