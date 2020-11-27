using System.Net;

namespace DTO.Response
{
    public class HttpResponseDto : ResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
    }
}