using MediatR;

namespace Encore.Domain.Core.Messaging
{
    public class QueryList<TResponse, TSearch> : IRequest<TResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public TSearch? Search { get; set; }
    }
}
