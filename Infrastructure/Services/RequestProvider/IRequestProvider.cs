using DTO;
using Infrastructure.Request;

namespace Infrastructure.Services.RequestProvider
{
    public interface IRequestProvider
    {
        public IRequest GetRequestByProtocol(ProtocolType protocolType);
    }
}