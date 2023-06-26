using Encore.Application.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IMediator _mediator;

        public AuthController (IMediator mediator) => _mediator = mediator;

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] AuthUserCommand command)
        {
            var response = await _mediator.Send(command);            
            return CustomResponse(response);
        }

    }
}