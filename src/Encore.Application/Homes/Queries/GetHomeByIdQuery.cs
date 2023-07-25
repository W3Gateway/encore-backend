using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Homes.Queries
{
    public class GetHomeByIdQuery : Query<HomeResponse>
    {
        public Guid Id { get; }

        public GetHomeByIdQuery(Guid id) => Id = id;
    }
}
