using MediatR;

namespace Encore.Domain.Core.Messaging
{
    public class Query<TResponse> : IRequest<TResponse>
    {
    }
}