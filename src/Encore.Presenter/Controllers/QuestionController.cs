using Encore.Application.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Encore.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ApiController
    {
        private readonly IMediator _mediator;

        public QuestionController (IMediator mediator) => _mediator = mediator;

        [HttpGet("get")]
        public async Task<ActionResult> GetQuestions()
        {
            var response = await _mediator.Send(new QuestionListCommand());
            return CustomResponse(response);
        }
    }
}