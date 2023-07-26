using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Visits.Queries
{
    public class GetVisitByIdQuery : Query<VisitResponse>
    {
        public Guid Id { get; }

        public GetVisitByIdQuery(Guid id) => Id = id;
    }
}
