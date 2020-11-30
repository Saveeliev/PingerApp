using DTO.Enums;

namespace DTO.Request
{
    public class RequestDto
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public ProtocolType ProtocolType { get; set; }
        public int Delay { get; set; }
    }
}