﻿using DTO.Enums;
using DTO.Request;
using DTO.Response;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Request
{
    public class TcpRequest : IRequest
    {
        private readonly ILogger _logger;

        public TcpRequest(ILogger<TcpRequest> logger)
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

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

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