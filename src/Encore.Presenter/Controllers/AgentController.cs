using Encore.Application.Agents.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ApiController
    {
        private readonly IMediator _mediator;

        public AgentController(IMediator mediator) => _mediator = mediator;

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] GetAgentByUserIdQuery query)
        {
            var response = await _mediator.Send(query);
            return CustomResponse(response);
        }
    }
}