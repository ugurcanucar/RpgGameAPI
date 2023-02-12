using Microsoft.AspNetCore.Mvc;
using RpgGameAPI.Dtos.Character;
using RpgGameAPI.Dtos.Class;
using RpgGameAPI.Models;
using RpgGameAPI.Services.ClassService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RpgGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetClassResponseDto>>>> Get()
        {
            return Ok(await classService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetClassResponseDto>>>> GetById(int id)
        {
            return Ok(await classService.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetClassResponseDto>>> Add(AddClassRequestDto character)
        {
            return Ok(await classService.Add(character));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetClassResponseDto>>> Update(UpdateClassRequestDto model)
        {
            var updatedCharacter = await classService.Update(model);
            if (updatedCharacter.Data is null) return NotFound(updatedCharacter);
            return Ok(updatedCharacter);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> DeleteById(int id)
        {
            var updatedCharacter = await classService.Delete(id);
            if (updatedCharacter.Data is null) return NotFound(updatedCharacter);
            return Ok(updatedCharacter);
        }

    }
}
