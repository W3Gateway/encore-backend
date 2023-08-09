using AutoMapper;
using Encore.Application.Persons.Commands;
using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Persons.Handlers
{
    public class PersonCreateCommandHandler : CommandHandler, IRequestHandler<PersonCreateCommand, Response<PersonResponse>?>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMicroregionRepository _microregionRepository;
        private readonly ISociodemographicSituationRepository _sociodemographicSituationRepository;
        private readonly IHealthConditionRepository _healthConditionRepository;
        private readonly IMapper _mapper;

        public PersonCreateCommandHandler(IPersonRepository personRepository,
                                        IHomeRepository homeRepository,
                                        IMicroregionRepository microregionRepository,
                                        ISociodemographicSituationRepository sociodemographicSituationRepository,
                                        IHealthConditionRepository healthConditionRepository,
                                        IMapper mapper) : base(personRepository.UnitOfWork)
        {
            _personRepository = personRepository;
            _homeRepository = homeRepository;
            _microregionRepository = microregionRepository;
            _sociodemographicSituationRepository = sociodemographicSituationRepository;
            _healthConditionRepository = healthConditionRepository;
            _mapper = mapper;

        }

        public async Task<Response<PersonResponse>?> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
        {
            await BeginTransactionAsync(cancellationToken);
            _executeTransaction = request.ExecuteTransaction;
            try
            {
                (var result, var entity) = await CreatePerson(request, cancellationToken);
                if (!result.IsValid)
                    return Fail<PersonResponse>(await RollbackAsync(cancellationToken));

                await CommitTransactionAsync(cancellationToken);
                return Success(_mapper.Map<PersonResponse>(entity), result);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de Indivíduo: " + ex.Message);
                return Fail<PersonResponse>(ValidationResult);
            }
        }

        private async Task<(ValidationResult result, Person entity)> CreatePerson(PersonCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Person>(request);
            var home = await _homeRepository.Include().FirstOrDefaultAsync(c => c.Id == request.HomeId);
            if (home is null)
            {
                AddError("Não foi encontrada o domicílio informado na base de dados");
                return (ValidationResult, entity);
            }

            var microregion = await _microregionRepository.Include().FirstOrDefaultAsync(c => c.Id == request.MicroregionId);
            if (microregion is null)
            {
                AddError("Não foi encontrada a microárea informada na base de dados");
                return (ValidationResult, entity);
            }

            if (!await IsValidAsync(entity))
                return (entity.ValidationResult, entity);
            
            var sociodemographic = _mapper.Map<SociodemographicSituation>(request);
            if (!await IsValidAsync(sociodemographic))
                return (sociodemographic.ValidationResult, entity);

            var healthCondition = _mapper.Map<HealthCondition>(request);
            if (!await IsValidAsync(healthCondition))
                return (healthCondition.ValidationResult, entity);

            entity = await _personRepository.CreateAsync(entity, cancellationToken);
            sociodemographic.AddPerson(entity.Id);
            await _sociodemographicSituationRepository.CreateAsync(sociodemographic, cancellationToken);
            healthCondition.AddPerson(entity.Id);
            await _healthConditionRepository.CreateAsync(healthCondition, cancellationToken);

            return (await CommitAsync(cancellationToken), entity);
        }
    }
}
