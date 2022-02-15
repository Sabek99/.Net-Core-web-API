using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Get()
        {
            return Ok(_characterService.GetAllCharacter());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id )
        {
            return Ok(_characterService.GetCharacterById(id));
        }


        [HttpPost]
        public IActionResult AddCharacter(Character newCharacter)
        {   
            _characterService.AddCharacter(newCharacter);
            return Ok(_characterService);
        }

    }
} 