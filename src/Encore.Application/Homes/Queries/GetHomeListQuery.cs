using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Homes.Queries
{
    public class GetHomeListQuery : QueryList<IEnumerable<HomeResponse>>
    {
        public Guid MicroregionId { get; set; }
    }
}
