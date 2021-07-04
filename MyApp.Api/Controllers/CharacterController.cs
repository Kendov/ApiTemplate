using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain;
using MyApp.Domain.Characters;
using MyApp.Domain.Characters.Commands;
using MyApp.Infrastructure;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CharacterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = await _mediator.Send(new ListCharactersQuery());
            return Ok(command);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCharacterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // [HttpPost]
        // public async Task<IActionResult> Add( command)
        // {
        //     var result = await _mediator.Send(command);
        //     return Ok(result);
        // }
    }
}