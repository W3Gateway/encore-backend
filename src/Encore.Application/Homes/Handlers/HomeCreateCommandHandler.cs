using AutoMapper;
using Encore.Application.Homes.Commands;
using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Homes.Handlers
{
    public class HomeCreateListCommandHandler : CommandHandler, IRequestHandler<HomeCreateListCommand, Response<List<HomeListResponse>>>
    {
        private readonly IMicroregionRepository _microregionRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMapper _mapper;

        public HomeCreateListCommandHandler(IMicroregionRepository microregionRepository,
                                        IAddressRepository addressRepository,
                                        IHomeRepository homeRepository,
                                        IMapper mapper) : base(homeRepository.UnitOfWork)
        {
            _microregionRepository = microregionRepository;
            _addressRepository = addressRepository;
            _homeRepository = homeRepository;
            _mapper = mapper;

        }

        public async Task<Response<List<HomeListResponse>>> Handle(HomeCreateListCommand request, CancellationToken cancellationToken)
        {
            await BeginTransactionAsync(cancellationToken);
            _executeTransaction = request.ExecuteTransaction;
            try
            {
                var homes = new List<HomeListResponse>();
                foreach (var item in request.Homes)
                {
                    var entity = _mapper.Map<Home>(item);
                    var result = await CreateHome(item, entity, cancellationToken);
                
                    if (!result.IsValid)
                        return Fail<List<HomeListResponse>>(await RollbackAsync(cancellationToken));
                   
                    await CommitAsync();
                    homes.Add(new HomeListResponse(item.AppId, entity.Id));
                }
                await CommitTransactionAsync(cancellationToken);
                return Success(homes);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de domicílio: " + ex.Message);
                return Fail<List<HomeListResponse>>(ValidationResult);
            }
        }

        private async Task<ValidationResult> CreateHome(HomeCreateCommand request, Home entity, CancellationToken cancellationToken)
        {
            var microregion = await _microregionRepository.Include().FirstOrDefaultAsync(c => c.Id == request.MicroregionId);
            if (microregion is null)
            {
                AddError("Não foi encontrada a microárea informado na base de dados");
                return ValidationResult;
            }

            var address = await CreateAddress(request, cancellationToken);
            if (!await IsValidAsync(address))
                return address.ValidationResult;

            if (!await IsValidAsync(entity))
                return entity.ValidationResult;

            entity = await _homeRepository.CreateAsync(entity, cancellationToken);
            entity.AddAddress(address.Id);

            await SaveAsync(cancellationToken);
            return await CommitAsync(cancellationToken);
        }

        private async Task<Address> CreateAddress(HomeCreateCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request.Address);
            if (!await address.IsValidAsync())
                AddError(address.ValidationResult.Errors);

            return await _addressRepository.CreateAsync(address, cancellationToken); ;
        }
    }
}
