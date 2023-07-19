using Encore.Domain.Core.Atributes;
using FluentValidation.Results;
using MediatR;

namespace Encore.Domain.Core.Messaging
{ 
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public Guid Id { get; set; }
        [SwaggerExclude]
        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public virtual Task<bool> IsValidAsync() => Task.FromResult(ValidationResult.IsValid);
    }

    public abstract class Command : Command<ValidationResult>
    {
    }
}