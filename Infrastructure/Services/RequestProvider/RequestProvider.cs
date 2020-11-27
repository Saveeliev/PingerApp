using DTO;
using Infrastructure.Request;

namespace Infrastructure.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        public IRequest GetRequestByProtocol(ProtocolType protocolType)
        {
            switch(protocolType)
            {
                case ProtocolType.http: return new HttpRequest();
                case ProtocolType.tcp: return new TcpRequest();
                case ProtocolType.icmp: return new IcmpRequest();
            }

            return null;
        }
    }
}