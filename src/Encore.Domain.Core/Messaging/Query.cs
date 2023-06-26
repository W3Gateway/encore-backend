using MediatR;

namespace VLI.PVDigital.Domain.Core.Messaging
{
    public class Query<TResponse> : IRequest<TResponse>
    {
    }
}