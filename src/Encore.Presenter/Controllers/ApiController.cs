using Encore.Domain.Core.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace Encore.Presenter.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    public abstract class ApiController : ControllerBase
    {
        private readonly List<string> _errors = new();
        protected readonly string _verbs = "GET,OPTIONS,POST,PATCH,PUT,DELETE";

        [HttpOptions]
        public ActionResult Options()
        {
            Response.Headers.Add("Allow", _verbs);
            return Ok();
        }

        protected ActionResult CustomResponse(object? result = default)
        {
            if (IsOperationValid())
            {
                if (HttpContext.Request.Method == "DELETE")
                    return NoContent();

                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomResponse<TResponse>(Response<TResponse> response)
        {
            if(response.ValidationResult.Errors.IsNullOrEmpty())
                foreach (var error in response.ValidationResult.Errors)
                    AddError(error.ErrorMessage);

            return CustomResponse(response.Data);
        }

        protected bool IsOperationValid() => !_errors.Any();

        protected ActionResult AddError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _errors.Add(error.ErrorMessage);

            return CustomResponse();
        }

        protected void AddError(string erro) => _errors.Add(erro);

        protected void ClearErrors() => _errors.Clear();

    }
}