using Encore.Application.User;
using Encore.Domain.Core.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    public abstract class ApiController : ControllerBase
    {
        private readonly List<string> _errors = new();
        protected readonly string _verbs = "GET,OPTIONS,POST,PUT,DELETE";

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", _verbs);
            return Ok();
        }

        protected ActionResult CustomResponse(Response<AuthUserResponse> response)
        {
            if (!response.IsValid)
            {
                AddError(response.ValidationResult);
                return Unauthorized(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Messages", _errors.ToArray() }
                }));
            }
            
            return Ok(response.Data);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _errors.Add(error.ErrorMessage);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }

    }
}