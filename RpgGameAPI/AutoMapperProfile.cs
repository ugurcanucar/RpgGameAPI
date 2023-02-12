using AutoMapper;
using RpgGameAPI.Dtos.Character;
using RpgGameAPI.Dtos.Class;
using RpgGameAPI.Models;

namespace RpgGameAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterResponseDto>();
            CreateMap<Character, AddCharacterRequestDto>().ReverseMap();
            CreateMap<Character, UpdateCharacterRequestDto>().ReverseMap();
            CreateMap<RoleClass, GetClassResponseDto>().ReverseMap();
            CreateMap<RoleClass, AddClassRequestDto>().ReverseMap();
        }
    }
}
