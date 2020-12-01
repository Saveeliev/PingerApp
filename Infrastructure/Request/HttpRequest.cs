using DTO.Enums;
using DTO.Request;
using DTO.Response;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Request
{
    public class HttpRequest : IRequest
    {
        public async Task<ResponseDto> GetResponse(RequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }

            var uri = new UriBuilder(requestDto.ProtocolType.ToString(), requestDto.Host, requestDto.Port);

            var request = WebRequest.CreateHttp(uri.Uri);
            request.Timeout = requestDto.DelayInMilliseconds;

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