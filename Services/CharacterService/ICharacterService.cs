using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Character;
using Models;

namespace Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacter();
        Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    }
}