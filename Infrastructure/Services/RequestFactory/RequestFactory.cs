using System;
using DTO.Enums;
using Infrastructure.Request;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.RequestFactory
{
    public class RequestFactory : IRequestFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public RequestFactory(IServiceProvider serviceProvider, ILogger<RequestFactory> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public IRequest GetRequestByProtocol(ProtocolType protocolType)
        {
            switch(protocolType)
            {
                case ProtocolType.Http: return (IRequest)_serviceProvider.GetRequiredService(typeof(HttpRequest));
                case ProtocolType.Tcp: return (IRequest)_serviceProvider.GetRequiredService(typeof(TcpRequest));
                case ProtocolType.Icmp: return (IRequest)_serviceProvider.GetRequiredService(typeof(IcmpRequest));
                default: 
                    var exceptionMessage = "No request type exists for this protocol type";
                    _logger.LogError(exceptionMessage);
                    throw new Exception(exceptionMessage);
            }
        }
    }
}