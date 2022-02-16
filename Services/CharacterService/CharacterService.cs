using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Character;
using Models;

namespace Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
         private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Name = "Sam"},
            new Character{Id = 1, Name = "Taransh", Intelligence = 150}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponce.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacter()
        {
            ServiceResponce<List<GetCharacterDto>> serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            serviceResponce.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponce<GetCharacterDto> serviceResponce = new ServiceResponce<GetCharacterDto>();
            serviceResponce.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponce;
        }
    }
}