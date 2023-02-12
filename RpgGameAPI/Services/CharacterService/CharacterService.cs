using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RpgGameAPI.Data;
using RpgGameAPI.Dtos.Character;
using RpgGameAPI.Models;

namespace RpgGameAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto character)
        {
            Character newCharacter = _mapper.Map<Character>(character);
            await _context.Characters.AddAsync(newCharacter);
            await _context.SaveChangesAsync();
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            List<Character> characters = await _context.Characters.ToListAsync();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            try
            {
                Character? c = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
                 
                if (c is null)
                {

                    throw new Exception("Character is not found");
                }
                  _context.Characters.Remove(c);
                await _context.SaveChangesAsync();
                List<Character> characters = await _context.Characters.ToListAsync(); 
                serviceResponse.Data = characters.Select(x=>_mapper.Map<GetCharacterResponseDto>(x)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Data = null;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();

            var xy = (from c in _context.Characters
                      join cl in _context.Classes on c.ClassId equals cl.Id select c

                       ).ToList(); 
            List<Character> dbCharacters = await _context.Characters.ToListAsync();

            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();

            return serviceResponse;
        }



        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            Character? dbCharacter =await _context.Characters.FirstOrDefaultAsync(x => x.Id == id); 
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(dbCharacter);
            return serviceResponse;


        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto character)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            try
            { 
                Character? c = await _context.Characters.FirstOrDefaultAsync(x => x.Id == character.Id);
                if (c is null)
                {

                    throw new Exception("Character is null");
                }
                c.Name = character.Name;
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(c);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Data = null;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
