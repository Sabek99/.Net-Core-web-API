using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Character;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
         private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Name = "Sam"},
            new Character{Id = 1, Name = "Theo", Intelligence = 150}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context )
        {
            this._context = context;
            this._mapper = mapper;
        }

         public async Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            
            await _context.characters.AddAsync(character);
            await _context.SaveChangesAsync();
            serviceResponce.Data = (_context.characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponce;
        }
        

        public async Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacter()
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            List<Character> dbCharacters = await _context.characters.ToListAsync();
            serviceResponce.Data = (dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
            Character dbCharacter = await _context.characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponce.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
            try{
            Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
            character.Name = updateCharacter.Name;
            character.Class = updateCharacter.Class;
            character.Defence = updateCharacter.Defence;
            character.HitPoint = updateCharacter.HitPoints;
            character.Intelligence = updateCharacter.Intelligence;
            character.Strength = character.Strength;

            serviceResponce.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex){
                 serviceResponce.Success = false;
                 serviceResponce.Message = ex.Message;
            }
            return serviceResponce;
        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            try{
            Character character = characters.First(c => c.Id == id);
            characters.Remove(character);

            serviceResponce.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch(Exception ex){
                 serviceResponce.Success = false;
                 serviceResponce.Message = ex.Message;
            }
            return serviceResponce;
        }

       
    }
}