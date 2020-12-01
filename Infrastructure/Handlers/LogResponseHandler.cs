using DTO.Enums;
using DTO.Response;
using System;
using System.IO;
using System.Text;

namespace Infrastructure.Handlers
{
    public static class LogResponseHandler
    {
        private static object _locker = 0;
        public static void WriteResponseInConsole(ResponseDto responseDto)
        {
            Console.WriteLine(GetLogString(responseDto));
        }

        public static void WriteResponseInFile(ResponseDto responseDto)
        {
            var path = @"D:\StaticFiles\logs.log";

            lock(_locker)
            {
                using var stream = new FileStream(path, FileMode.OpenOrCreate);

                stream.Seek(0, SeekOrigin.End);

                var bytes = Encoding.Default.GetBytes(GetLogString(responseDto) + "\n");

                stream.Write(bytes, 0, bytes.Length);
            }
        }

        private static string GetLogString(ResponseDto responseDto)
        {
            var responseStatus = responseDto.Status;
            var status = responseDto.Status.ToString();

            if (responseStatus == ResponseStatus.InvalidResponse)
            {
                status = "Invalid response";
            }
            return string.Format("{0} {1} {2}", responseDto.Date, responseDto.Host, status);
        }
    }
}