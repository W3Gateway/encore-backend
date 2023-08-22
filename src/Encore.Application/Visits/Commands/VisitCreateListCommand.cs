using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Visits.Commands
{
    public class VisitCreateListCommand : Command<Response<List<VisitListResponse>>>
    {
        public IEnumerable<VisitCreateCommand> Visits { get; set; }
        public bool ExecuteTransaction { get; set; } = true;
    }
}
