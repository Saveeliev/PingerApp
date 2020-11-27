using System;

namespace DTO.Response
{
    public class ResponseDto
    {
        public string Host { get; set; }
        public DateTime Date { get; set; }
        public ResponseStatus Status { get; set; }
    }
}