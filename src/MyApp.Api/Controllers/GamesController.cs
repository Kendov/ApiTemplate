using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Games.CreateGameCommand;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll([FromQuery] ListGamesQuery command)
        // {
        //     var result = await _mediator.Send(command);
        //     return Ok(result);
        // }

        [HttpPost]
        public async Task<IActionResult> Add(CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}