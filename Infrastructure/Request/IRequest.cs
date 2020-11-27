using DTO;
using DTO.Request;
using DTO.Response;

namespace Infrastructure.Request
{
    public interface IRequest
    {
        ResponseDto GetResponse(RequestDto req);
    }
}