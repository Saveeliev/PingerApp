using DTO.Enums;
using DTO.Request;
using DTO.Response;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Infrastructure.Request
{
    public class IcmpRequest : IRequest
    {
        public async Task<ResponseDto> GetResponseAsync(RequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, System.Net.Sockets.ProtocolType.Icmp);

            IAsyncResult connectResult = socket.BeginConnect(requestDto.Host, requestDto.Port, null, null);

            var success = connectResult.AsyncWaitHandle.WaitOne();

            var result = new ResponseDto
            {
                Host = requestDto.Host,
                Date = DateTime.Now
            };

            try
            {
                if (success)
                {
                    socket.EndConnect(connectResult);
                    result.Status = ResponseStatus.Ok;
                }
                else
                {
                    socket.Close();
                    result.Status = ResponseStatus.Fail;
                }
            }
            catch (Exception)
            {
                socket.Close();
                result.Status = ResponseStatus.Fail;
            }


            return result;
        }
    }
}
