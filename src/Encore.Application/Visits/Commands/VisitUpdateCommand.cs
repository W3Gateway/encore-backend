using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Visits.Commands
{
    public class VisitUpdateCommand : Command<Response<VisitResponse>>
    {
        public Guid AgentId { get; set; }
        public Guid PersonId { get; set; }
        public Guid HomeId { get; set; }
        public Guid MicroregionId { get; set; }
        public IEnumerable<QuestionAnswer> Answers { get; set; }
    }
}