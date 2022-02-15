using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ServiceResponce<List<Character>>> AddCharacter(Character newCharacter)
        {
            ServiceResponce<List<Character>> serviceResponce = new ServiceResponce<List<Character>>();
            characters.Add(newCharacter);
            serviceResponce.Data = characters;
            return serviceResponce;
        }

        public async Task<ServiceResponce<List<Character>>> GetAllCharacter()
        {
            ServiceResponce<List<Character>> serviceResponce = new ServiceResponce<List<Character>>();
            serviceResponce.Data = characters;
            return serviceResponce;
        }

        public async Task<ServiceResponce<Character>> GetCharacterById(int id)
        {
            ServiceResponce<Character> serviceResponce = new ServiceResponce<Character>();
            serviceResponce.Data = characters.FirstOrDefault(c => c.Id == id);
            return serviceResponce;
        }
    }
}