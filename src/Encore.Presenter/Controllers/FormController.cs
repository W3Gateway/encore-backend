using Encore.Application.Forms.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ApiController
    {
        private readonly IMediator _mediator;

        public FormController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Get([FromQuery] FormQuery query)
        {
            var response = await _mediator.Send(query);
            return CustomResponse(response);
        }
    }
}