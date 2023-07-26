using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Visits.Queries
{
    public class GetVisitListQuery : Query<IEnumerable<VisitResponse>>
    {
        public Guid MicroregionId { get; }
    }
}
