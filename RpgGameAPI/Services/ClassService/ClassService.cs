using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RpgGameAPI.Data;
using RpgGameAPI.Dtos.Class;
using RpgGameAPI.Models;

namespace RpgGameAPI.Services.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public ClassService(IMapper mapper , DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<List<GetClassResponseDto>>> Add(AddClassRequestDto model)
        {
            await context.Classes.AddAsync(mapper.Map<RoleClass>(model));
            await context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<List<GetClassResponseDto>>();
            serviceResponse.Data = await context.Classes.Select(c=>mapper.Map<GetClassResponseDto>(c)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClassResponseDto>>> Delete(int id)
        {
            var character = await context.Classes.FirstOrDefaultAsync(c => c.Id == id);
              context.Remove(character);
            await context.SaveChangesAsync();
            var serviceResponse = new ServiceResponse<List<GetClassResponseDto>>();
            serviceResponse.Data= await context.Classes.Select(c=> mapper.Map<GetClassResponseDto>(c)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClassResponseDto>>> GetAll()
        {
            ServiceResponse<List<GetClassResponseDto>> response =new ServiceResponse<List<GetClassResponseDto>>();

            List<GetClassResponseDto> classes = await context.Classes.Select(c => mapper.Map<GetClassResponseDto>(c)).ToListAsync(); 
            response.Data = classes;
            return response;

        }

        public async Task<ServiceResponse<GetClassResponseDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetClassResponseDto>();
            serviceResponse.Data = mapper.Map<GetClassResponseDto>(await context.Classes.FirstOrDefaultAsync(c => c.Id == id));
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetClassResponseDto>> Update(UpdateClassRequestDto updatedModel)
        {
            var character = await context.Classes.FirstOrDefaultAsync(c => c.Id == updatedModel.Id);
            character.Name=updatedModel.Name; 
            character.MaxLevel=updatedModel.MaxLevel;
            await context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<GetClassResponseDto>();
            serviceResponse.Data = mapper.Map<GetClassResponseDto>(character);

            return serviceResponse;
        }
    }
}
