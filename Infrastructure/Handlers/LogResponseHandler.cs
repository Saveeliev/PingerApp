using DTO;
using DTO.Request;
using DTO.Response;
using System;

namespace Infrastructure.Handlers
{
    public static class LogResponseHandler
    {
        public static void WriteResponse(ResponseDto responseDto)
        {
            if(responseDto is HttpResponseDto)
            {
                var response = (HttpResponseDto)responseDto;

                if(response.StatusCode != 0)
                {
                    Console.WriteLine("{0} {1} {2} {3}", responseDto.Date, responseDto.Host, responseDto.Status, (int)response.StatusCode);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", responseDto.Date, responseDto.Host, responseDto.Status);
                }
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", responseDto.Date, responseDto.Host, responseDto.Status);
            }
        }
    }
}