using AutoMapper;
using Encore.Application.Homes.Commands;
using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Data;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Homes;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Homes.Handlers
{
    public class HomeUpdateCommandHandler : CommandHandler, IRequestHandler<HomeUpdateCommand, Response<HomeResponse>>
    {
        private readonly IMicroregionRepository _microregionRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMapper _mapper;

        public HomeUpdateCommandHandler(IMicroregionRepository microregionRepository,
                                        IHomeRepository homeRepository,
                                        IMapper mapper) : base(homeRepository.UnitOfWork)
        {
            _microregionRepository = microregionRepository;
            _homeRepository = homeRepository;
            _mapper = mapper;

        }

        public async Task<Response<HomeResponse>> Handle(HomeUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _homeRepository.GetByIdAsync(request.Id, cancellationToken);
                if (entity is null)
                {
                    AddError("Não foi encontrado o domicílio informado na base de dados");
                    return Fail<HomeResponse>(ValidationResult);
                }

                var microregion = await _microregionRepository.Include().FirstOrDefaultAsync(c => c.Id == request.MicroregionId);
                if (microregion is null)
                {
                    AddError("Não foi encontrada a microárea informado na base de dados");
                    return Fail<HomeResponse>(ValidationResult);
                }

                var entityValidade = entity.ValidateRules(_mapper.Map<Home>(request));
                if (!entityValidade.IsValid)
                {
                    AddError(entityValidade.Errors);
                    return Fail<HomeResponse>(ValidationResult);
                }

                entity.CopyProperties(microregion.Id, request.Address, request.ContactNumber, request.MedicalRecordNumber, request.HouseholdIncome, request.NumberMembers);
                entity = await _homeRepository.UpdateAsync(entity, cancellationToken);
                await SaveAsync(cancellationToken);
                return Success(_mapper.Map<HomeResponse>(entity));
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de domicílio: " + ex.Message);
                return Fail<HomeResponse>(ValidationResult);
            }
        }
    }
}
