using Encore.Application.Homes.Responses;
using Encore.Application.Homes.Search;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Homes.Queries
{
    public class GetHomeListQuery : QueryList<IEnumerable<HomeResponse>, HomeSearch>
    {
        public Guid MicroregionId { get; set; }
    }
}
