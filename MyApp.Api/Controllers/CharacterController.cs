using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Characters;
using MyApp.Infrastructure;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IUnitOfWork unitOfWork;
        public CharacterController(ICharacterRepository characterRepository, IUnitOfWork unitOfWork)
        {
            this.characterRepository = characterRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(characterRepository.CustomFindAll());
        }

        [HttpPost]
        public IActionResult Add(Character character)
        {
            characterRepository.Insert(character);
            unitOfWork.Commit();
            return Ok(character);
        }
    }
}