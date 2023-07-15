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

        protected ActionResult CustomResponse(object result = default)
        {
            if (IsOperationValid())
                return Ok($"\"{result}\"");

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected bool IsOperationValid() => !_errors.Any();

        protected ActionResult AddError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _errors.Add(error.ErrorMessage);

            return CustomResponse();
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }

    }
}