using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Games.CreateGameCommand;
using MyApp.Application.Games.GetGamesByIdQuery;
using MyApp.Application.Games.ListGamesQuery;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetGamesByIdQuery { Id = id }).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListGamesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}