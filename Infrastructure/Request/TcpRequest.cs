using DTO;
using DTO.Request;
using DTO.Response;
using System;
using System.Net.Sockets;

namespace Infrastructure.Request
{
    public class TcpRequest : IRequest
    {
        public ResponseDto GetResponse(RequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

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
                    result.Status = ResponseStatus.OK;
                }
                else
                {
                    socket.Close();
                    result.Status = ResponseStatus.FAIL;
                }
            }
            catch (Exception)
            {
                socket.Close();
                result.Status = ResponseStatus.FAIL;
            }

            return result;
        }
    }
}