using Microsoft.AspNetCore.Mvc;
using RpgGameAPI.Dtos.Character;
using RpgGameAPI.Models;
using RpgGameAPI.Services.CharacterService;

namespace RpgGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;


        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> GetById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> Add(AddCharacterRequestDto character)
        {
            return Ok(await _characterService.AddCharacter(character));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> Update(UpdateCharacterRequestDto character)
        {
            var updatedCharacter = await _characterService.UpdateCharacter(character);
            if (updatedCharacter.Data is null) return NotFound(updatedCharacter);
            return Ok(updatedCharacter);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> DeleteById(int id)
        {
            var updatedCharacter = await _characterService.DeleteCharacterById(id);
            if (updatedCharacter.Data is null) return NotFound(updatedCharacter);
            return Ok(updatedCharacter);
        }

    }
}
