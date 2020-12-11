using DTO.Enums;
using DTO.Request;
using DTO.Response;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Request
{
    public class HttpRequest : IRequest
    {
        private readonly ILogger _logger;

        public HttpRequest(ILogger<HttpRequest> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ResponseDto> GetResponseAsync(RequestDto requestDto)
        {
            if (requestDto is null)
            {
                _logger.LogError("RequestDto cannot be null");
                throw new ArgumentNullException(nameof(requestDto));
            }

            var uri = new UriBuilder(requestDto.ProtocolType.ToString(), requestDto.Host, requestDto.Port);

            var request = WebRequest.CreateHttp(uri.Uri);

            var result = new ResponseDto()
            {
                Host = requestDto.Host
            };

            try
            {
                var response = await request.GetResponseAsync();

                var responseResult = (HttpWebResponse)response;

                result.Date = DateTime.Now;

                if(responseResult.StatusCode == requestDto.ValidStatusCode)
                {
                    result.Status = ResponseStatus.Ok;
                }
                else
                {
                    result.Status = ResponseStatus.InvalidResponse;
                }

                response.Close();
            }
            catch(Exception)
            {
                result.Status = ResponseStatus.Fail;
                result.Date = DateTime.Now;
            }

            return result;
        }
    }
}