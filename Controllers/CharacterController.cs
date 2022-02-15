using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController] 
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Name = "Sam"},
            new Character{Id = 1, Name = "Taransh", Intelligence = 150}
        };

        [Route("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id )
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }


        [HttpPost]
        public IActionResult AddCharacter(Character newCharacter)
        {   
            characters.Add(newCharacter);
            return Ok(characters);
        }

    }
} 