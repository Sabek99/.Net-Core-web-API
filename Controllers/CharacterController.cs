using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Character;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services.CharacterService;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController] 
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
            
        }

        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacter());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id )
        {
            return Ok(await _characterService.GetCharacterById(id));
        }


        [HttpPost]
        public async Task<IActionResult>  AddCharacter(AddCharacterDto newCharacter)
        {   
            
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult>  UpdateCharacter(UpdateCharacterDto UpdateCharacter)
        {   
            ServiceResponce<GetCharacterDto> responce = await _characterService.UpdateCharacter(UpdateCharacter);
            if(responce.Data == null)
                return NotFound(responce);

            return Ok(responce);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {
            ServiceResponce<List<GetCharacterDto>> responce = await _characterService.DeleteCharacter(id);
            if(responce.Data == null)
                return NotFound(responce);

            return Ok(responce);
        }


    }
} 