using Encore.Application.Questions;
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

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new QuestionListQuery());
            return CustomResponse(response);
        }
    }
}