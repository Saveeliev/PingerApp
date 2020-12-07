using DTO.Request;
using DTO.Response;
using System;

namespace Infrastructure.Handlers
{
    public class PingHandlerArgs : EventArgs
    {
        public ResponseDto ResponseDto { get; set; }
    }
}
