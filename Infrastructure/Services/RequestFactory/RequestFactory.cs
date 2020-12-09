using System;
using DTO.Enums;
using Infrastructure.Request;

namespace Infrastructure.Services.RequestFactory
{
    public class RequestFactory : IRequestFactory
    {
        public IRequest GetRequestByProtocol(ProtocolType protocolType)
        {
            switch(protocolType)
            {
                case ProtocolType.Http: return new HttpRequest();
                case ProtocolType.Tcp: return new TcpRequest();
                case ProtocolType.Icmp: return new IcmpRequest();
                default: throw new Exception("No request type exists for this protocol type");
            }
        }
    }
}