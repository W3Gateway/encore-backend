using AutoMapper;
using Encore.Application.Homes.Commands;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace Encore.Application.Homes.Handlers
{
    public class HomeUpdateCommandHandler : CommandHandler, IRequestHandler<HomeUpdateListCommand, ValidationResult>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMapper _mapper;

        public HomeUpdateCommandHandler(IAddressRepository addressRepository,
                                        IHomeRepository homeRepository,
                                        IMapper mapper) : base(homeRepository.UnitOfWork)
        {
            _addressRepository = addressRepository;
            _homeRepository = homeRepository;
            _mapper = mapper;

        }

        public async Task<ValidationResult> Handle(HomeUpdateListCommand request, CancellationToken cancellationToken)
        {
            await BeginTransactionAsync(cancellationToken);
            _executeTransaction = request.ExecuteTransaction;
            try
            {
                foreach (var item in request.Homes)
                {
                    var entity = await _homeRepository.GetByIdAsync(item.Id, cancellationToken);
                    if (entity is null)
                    {
                        AddError($"Não foi encontrado o domicílio informado na base de dados para o endereço: {item.Address.Street} - {item.Address.Number}");
                        return ValidationResult;
                    }

                    var result = await HomeUpdate(entity, item, cancellationToken);
                    if (!result.IsValid)
                        return await RollbackAsync(cancellationToken);
                }
                await CommitTransactionAsync();
                return ValidationResult;
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de domicílio: " + ex.Message);
                return ValidationResult;
            }
        }

        private async Task<ValidationResult> HomeUpdate(Home entity, HomeUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await UpdateAddress(entity.Address, request, cancellationToken);
            if (!result.IsValid)
                return result;

            entity.Update(_mapper.Map<Home>(request));
            var entityValidade = entity.ValidateRules(entity);
            if (!entityValidade.IsValid)
            {
                AddError(entityValidade.Errors);
                return entityValidade;
            }
            await _homeRepository.UpdateAsync(entity, cancellationToken);
            return await CommitAsync(cancellationToken);
        }

        private async Task<ValidationResult> UpdateAddress(Address address, HomeUpdateCommand request, CancellationToken cancellationToken)
        {
            var addressMap = _mapper.Map<Address>(request.Address);
            address.Update(addressMap);

            if (!await address.IsValidAsync())
                AddError(address.ValidationResult.Errors);

            await _addressRepository.UpdateAsync(address, cancellationToken);
            return ValidationResult;
        }
    }
}
