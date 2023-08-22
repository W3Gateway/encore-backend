using Encore.Application.Homes.Commands;
using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Visits.Commands
{
    public class VisitCreateCommand : Command<Response<VisitResponse>>
    {
        public Guid AgentId { get; set; }
        public Guid PersonId { get; set; }
        public Guid HomeId { get; set; }
        public Guid MicroregionId { get; set; }
        public IEnumerable<VisitAnswerCreateCommand> Answers { get; set; }
    }
}
