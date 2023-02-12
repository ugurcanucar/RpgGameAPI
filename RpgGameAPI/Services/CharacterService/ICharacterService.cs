using RpgGameAPI.Dtos.Character;
using RpgGameAPI.Models;

namespace RpgGameAPI.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();

        Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto character);

        Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto character);

        Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacterById(int id);

    }
}
