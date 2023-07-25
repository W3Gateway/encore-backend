using Encore.Domain.Core.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Pipelines
{
    public class TransactionPipeline<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly IUnitOfWork _uow;

        public TransactionPipeline(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<TOut> Handle(TIn request, RequestHandlerDelegate<TOut> next, CancellationToken cancellationToken)
        {
            TOut result = default;
            var strategy = _uow.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () => result = await next());

            return result;
        }
    }
}
