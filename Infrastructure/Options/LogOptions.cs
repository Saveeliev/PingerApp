using DTO.Enums;

namespace Infrastructure.Options
{
    public class LogOptions
    {
        public string PathToLogFile { get; set; }
        public LogWay[] LogWays { get; set; }
    }
}