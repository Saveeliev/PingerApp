using DTO.Enums;
using DTO.Response;

namespace Infrastructure.Helpers
{
    public static class LogHelper
    {
        public static string GetLogString(ResponseDto responseDto)
        {
            if (responseDto is null)
            {
                throw new System.ArgumentNullException(nameof(responseDto));
            }

            var responseStatus = responseDto.Status;
            var status = responseDto.Status.ToString();

            if (responseStatus == ResponseStatus.InvalidResponse)
            {
                status = "Invalid response";
            }
            return string.Format("{0} {1} {2}", responseDto.Date, responseDto.Host, status);
        }
    }
}