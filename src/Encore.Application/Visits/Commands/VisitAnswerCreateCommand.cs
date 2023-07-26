using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Visits.Commands
{
    public class VisitAnswerCreateCommand : Command<Response<VisitResponse>>
    {
        public Guid QuestionId { get; set; }
        public string? Response { get; set; }
    }
}
