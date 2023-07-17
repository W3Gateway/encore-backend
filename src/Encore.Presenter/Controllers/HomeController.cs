using Encore.Application.Home;
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
        public async Task<ActionResult> Create([FromBody] CreateHomeCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }
    }
}