using Encore.Domain.Core.Data;
using Encore.Domain.Core.Models;
using Encore.Domain.Core.Responses;
using FluentValidation.Results;

namespace Encore.Domain.Core.Messaging
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;

        protected bool _executeTransaction = true;
        protected ValidationResult ValidationResult { get; } = new ValidationResult();

        protected CommandHandler(IUnitOfWork unitOfWork) => _uow = unitOfWork;

        protected Task<int> SaveAsync(CancellationToken cancellationToken = default) =>
            _uow.SaveAsync(cancellationToken);

        protected async Task<ValidationResult> CommitAsync(string message, CancellationToken cancellationToken = default)
        {
            if (_uow.HasChanges() && (await _uow.SaveAsync(cancellationToken) <= 0))
                AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await CommitAsync("Ocorreu um erro ao salvar os dados!", cancellationToken);
        }

        protected async Task<ValidationResult> RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _uow.RollbackTransactionAsync(cancellationToken);
            return ValidationResult;
        }

        protected bool HasChanges()
        {
            return _uow.HasChanges();
        }


        protected async Task<bool> IsValidAsync<TParameter>(TParameter target) where TParameter : Entity<TParameter>
        {
            await target.IsValidAsync();
            foreach (var error in target.ValidationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected bool IsSuccess(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected void AddError(string mensagem) => ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));

        protected void AddError(List<ValidationFailure> errors) => ValidationResult.Errors.AddRange(errors);

        protected static TEntity Remover<TEntity>(TEntity entity)
            where TEntity : Entity<TEntity>
        {
            entity.Ativo = false;
            entity.ModifiedDate = DateTime.UtcNow;
            return entity;
        }

        protected static Response<TData> Success<TData>(TData data, ValidationResult? validationResult = default) => 
            Response<TData>.Success(data, validationResult);

        protected static Response<TData> Fail<TData>(ValidationResult? validationResult = default) =>
            Response<TData>.Fail(validationResult);

        protected static List<TEntity> Remover<TEntity>(List<TEntity> entities)
            where TEntity : Entity<TEntity>
        {
            return entities.Select(x =>
            {
                x = Remover(x);
                return x;
            }).ToList();
        }


    }
}