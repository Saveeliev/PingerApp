using DTO.Enums;
using Infrastructure.Request;

namespace Infrastructure.Services.RequestFactory
{
    public interface IRequestFactory
    {
        public IRequest GetRequestByProtocol(ProtocolType protocolType);
    }
}