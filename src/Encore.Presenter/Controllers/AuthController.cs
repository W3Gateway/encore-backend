using Encore.Application.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IMediator _mediator;

        public AuthController (IMediator mediator) => _mediator = mediator;

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateUser([FromBody] AuthUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response is null)
                return Unauthorized(command);
            
            return CustomResponse(response);
        }
    }
}