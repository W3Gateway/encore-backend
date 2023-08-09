using Encore.Application.Homes.Commands;
using Encore.Application.Homes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ApiController
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] HomeCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Get([FromQuery] GetHomeListQuery query)
        {
            var response = await _mediator.Send(query);
            return CustomResponse(response);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _mediator.Send(new GetHomeByIdQuery(id));
            return CustomResponse(response);
        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Patch(Guid id,[FromBody] HomeUpdateCommand command)
        {
            command.Id = id;
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }
    }
}