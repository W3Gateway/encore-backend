using Encore.Application.User;
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
        public async Task<ActionResult> Create([FromBody] AuthUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response is null)
                return Unauthorized(command);

            return CustomResponse(response);
        }
    }
}