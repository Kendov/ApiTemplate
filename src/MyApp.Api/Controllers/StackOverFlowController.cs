using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.StackOverflow.Queries;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class StackOverflowController : ControllerBase
    {
        private readonly IMediator mediator;

        public StackOverflowController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ListPostsQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return Ok("Error!");
        // }
    }
}
