using DTO;
using DTO.Request;
using DTO.Response;
using System;
using System.Net;

namespace Infrastructure.Request
{
    public class HttpRequest : IRequest
    {
        public ResponseDto GetResponse(RequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }

            var uri = new UriBuilder(requestDto.ProtocolType.ToString(), requestDto.Host, requestDto.Port);

            var request = WebRequest.CreateHttp(uri.Uri);
            request.Timeout = requestDto.Delay;

            var result = new HttpResponseDto()
            {
                Host = requestDto.Host
            };

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                var date = response.Headers.Get("Date");
                result.Date = DateTime.Parse(date);
                result.Status = ResponseStatus.OK;
                result.StatusCode = response.StatusCode;

                response.Close();
            }
            catch(Exception)
            {
                result.Status = ResponseStatus.FAIL;
                result.Date = DateTime.Now;
            }

            return result;
        }
    }
}