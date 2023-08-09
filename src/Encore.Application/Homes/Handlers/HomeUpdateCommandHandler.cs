using AutoMapper;
using Encore.Application.Homes.Commands;
using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace Encore.Application.Homes.Handlers
{
    public class HomeUpdateCommandHandler : CommandHandler, IRequestHandler<HomeUpdateCommand, Response<HomeResponse>>
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

        public async Task<Response<HomeResponse>> Handle(HomeUpdateCommand request, CancellationToken cancellationToken)
        {
            await BeginTransactionAsync(cancellationToken);
            _executeTransaction = request.ExecuteTransaction;
            try
            {
                var entity = await _homeRepository.GetByIdAsync(request.Id, cancellationToken);
                if (entity is null)
                {
                    AddError("Não foi encontrado o domicílio informado na base de dados");
                    return Fail<HomeResponse>(ValidationResult);
                }

                var result = await HomeUpdate(entity, request, cancellationToken);
                if (result.IsValid)
                    return Fail<HomeResponse>(await RollbackAsync(cancellationToken));
                
                await CommitTransactionAsync();
                return Success(_mapper.Map<HomeResponse>(entity));
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de domicílio: " + ex.Message);
                return Fail<HomeResponse>(ValidationResult);
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
            entity = await _homeRepository.UpdateAsync(entity, cancellationToken);

            return await CommitAsync(cancellationToken);
        }

        private async Task<ValidationResult> UpdateAddress(Address address, HomeUpdateCommand request, CancellationToken cancellationToken)
        {
            var addressMap = _mapper.Map<Address>(request);
            address.Update(addressMap);

            if (!await address.IsValidAsync())
                AddError(address.ValidationResult.Errors);

            await _addressRepository.UpdateAsync(address, cancellationToken);
            return ValidationResult;
        }
    }
}
