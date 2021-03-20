using Microsoft.AspNetCore.Mvc;
using MyApp.Domain;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository characterRepository;
        public CharacterController(ICharacterRepository characterRepository)
        {
            this.characterRepository = characterRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(characterRepository.CustomFindAll());
        }

        [HttpPost]
        public IActionResult Add(Character character)
        {
            characterRepository.Add(character);
            return Ok();
        }
    }
}