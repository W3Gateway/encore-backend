using Encore.Application.Visits.Commands;
using Encore.Application.Visits.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    public class VisitController : ApiController
    {
        private readonly IMediator _mediator;

        public VisitController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] VisitCreateListCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] GetVisitListQuery query)
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
            var response = await _mediator.Send(new GetVisitByIdQuery(id));
            return CustomResponse(response);
        }

        [HttpPatch()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Patch([FromBody] VisitUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }
    }
}