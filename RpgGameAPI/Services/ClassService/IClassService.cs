using RpgGameAPI.Dtos.Class;
using RpgGameAPI.Models;

namespace RpgGameAPI.Services.ClassService
{
    public interface IClassService
    {
       Task<ServiceResponse<List<GetClassResponseDto>>> GetAll();
        Task<ServiceResponse<GetClassResponseDto>> GetById(int id);
        Task<ServiceResponse<List<GetClassResponseDto>>> Add(AddClassRequestDto model);
        Task<ServiceResponse<GetClassResponseDto>> Update(UpdateClassRequestDto id);
        Task<ServiceResponse<List<GetClassResponseDto>>> Delete(int id);
    }
}
