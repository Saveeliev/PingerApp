using DTO.Enums;
using DTO.Request;
using System.Net;

namespace PingerApp.Tests.Helpers
{
    public static class HostValidatorHelper
    {
        public static RequestDto GetValidRequestDto()
        {
            return new RequestDto
            {
                Host = "ya.ru",
                Port = 80,
                ProtocolType = ProtocolType.Http,
                DelayInMilliseconds = 2000,
                ValidStatusCode = HttpStatusCode.OK
            };
        }
    }
}