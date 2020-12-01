using DTO.Enums;
using System.Net;

namespace DTO.Request
{
    public class RequestDto
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public ProtocolType ProtocolType { get; set; }
        public int DelayInMilliseconds { get; set; }
        public HttpStatusCode ValidStatusCode { get; set; }
    }
}