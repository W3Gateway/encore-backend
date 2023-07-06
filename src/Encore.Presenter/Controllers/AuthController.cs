using Encore.Application.User;
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

        //[HttpPost("register")]
        //public IActionResult Register([FromBody] RegisterModel model)
        //{
        //    //// Verificar se o email já está sendo usado
        //    //if (_userRepository.GetUserByEmail(model.Email) != null)
        //    //    return Conflict(new { message = "Email already exists" });

        //    //// Criar o hash da senha
        //    //var passwordHash = HashPassword(model.Password);

        //    //// Criar o novo usuário
        //    //var newUser = new User
        //    //{
        //    //    Email = model.Email,
        //    //    PasswordHash = passwordHash
        //    //};

        //    //// Salvar o usuário no repositório
        //    //_userRepository.AddUser(newUser);

        //    return CreatedAtAction();
        //}

    }
}