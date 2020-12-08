using DTO.Enums;
using Infrastructure.Request;

namespace Infrastructure.Services.RequestProvider
{
    public static class RequestProvider
    {
        public static IRequest GetRequestByProtocol(ProtocolType protocolType)
        {
            switch(protocolType)
            {
                case ProtocolType.Http: return new HttpRequest();
                case ProtocolType.Tcp: return new TcpRequest();
                case ProtocolType.Icmp: return new IcmpRequest();
            }

            return null;
        }
    }
}