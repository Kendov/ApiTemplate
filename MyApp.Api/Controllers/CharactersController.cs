using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Characters.Commands;
using MyApp.CrossCutting;
using MyApp.Domain.Characters;
using MyApp.Domain.Characters.Queries;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CharactersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ListCharactersQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCharacterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}