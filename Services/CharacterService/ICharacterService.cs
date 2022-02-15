using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<Character>>> GetAllCharacter();
        Task<ServiceResponce<Character>> GetCharacterById(int id);
        Task<ServiceResponce<List<Character>>> AddCharacter(Character newCharacter);
    }
}