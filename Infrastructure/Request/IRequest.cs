using DTO;
using DTO.Request;
using DTO.Response;
using System.Threading.Tasks;

namespace Infrastructure.Request
{
    public interface IRequest
    {
        Task<ResponseDto> GetResponseAsync(RequestDto req);
    }
}