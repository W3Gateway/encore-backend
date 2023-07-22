using Encore.Application.Homes;
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
        public async Task<ActionResult> Create([FromBody] CreateHomeCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        //[HttpGet()]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult> Get([FromQuery] GetHomesQuery query)
        //{
        //    var response = await _mediator.Send(query);
        //        return CustomResponse(response);
        //}
    }
}