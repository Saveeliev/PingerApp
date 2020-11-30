using DTO;
using DTO.Request;
using DTO.Response;
using System;
using System.Net.Sockets;

namespace Infrastructure.Request
{
    public class IcmpRequest : IRequest
    {
        public ResponseDto GetResponse(RequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, System.Net.Sockets.ProtocolType.Icmp);

            IAsyncResult connectResult = socket.BeginConnect(requestDto.Host, requestDto.Port, null, null);

            var success = connectResult.AsyncWaitHandle.WaitOne(requestDto.Delay, true);

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
