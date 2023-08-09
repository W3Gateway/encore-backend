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
    public class PersonUpdateCommandHandler : CommandHandler, IRequestHandler<PersonUpdateCommand, Response<PersonResponse>?>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMicroregionRepository _microregionRepository;
        private readonly ISociodemographicSituationRepository _sociodemographicSituationRepository;
        private readonly IHealthConditionRepository _healthConditionRepository;
        private readonly IMapper _mapper;

        public PersonUpdateCommandHandler(IPersonRepository personRepository,
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

        public async Task<Response<PersonResponse>?> Handle(PersonUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                (var result, var entity ) = await UpdatePerson(request, cancellationToken);
                if (!result.IsValid)
                    return Fail<PersonResponse>(await RollbackAsync(cancellationToken));
                return Success(_mapper.Map<PersonResponse>(entity), result);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de Indivíduo: " + ex.Message);
                return Fail<PersonResponse>(ValidationResult);
            }
        }

        private async Task<(ValidationResult result, Person entity)> UpdatePerson(PersonUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _personRepository.GetByIdAsync(request.Id);
            if (entity is null)
            {
                AddError("Não foi encontrado o indivíduo informado na base de dados");
                return (ValidationResult, entity);
            }
            var home = await _homeRepository.GetByIdAsync(request.HomeId);
            if (home is null)
            {
                AddError("Não foi encontrado o domicílio informado na base de dados");
                return (ValidationResult, entity);
            }

            var microregion = await _microregionRepository.GetByIdAsync(request.MicroregionId);
            if (microregion is null)
            {
                AddError("Não foi encontrada a microárea informada na base de dados");
                return (ValidationResult, entity);
            }

            if (!await IsValidAsync(entity))
                return (entity.ValidationResult, entity);

            entity.CopyProperties(request.Name,
                                  request.SocialName,
                                  request.BirthDate,
                                  request.Nationality,
                                  request.Sex,
                                  request.SkinColor,
                                  request.Document,
                                  request.DocumentType,
                                  request.Email,
                                  request.ContactNumber,
                                  request.SocialIdentification,
                                  request.FatherName,
                                  request.MotherName,
                                  request.IsHeadFamily,
                                  request.MicroregionId,
                                  request.HomeId);

            var sociodemographic = await _sociodemographicSituationRepository.Include().FirstOrDefaultAsync(s => s.PersonId == entity.Id);
            var healthCondition = await _healthConditionRepository.Include().FirstOrDefaultAsync(s => s.PersonId == entity.Id);
            sociodemographic.CopyProperties(_mapper.Map<SociodemographicSituation>(request.SociodemographicSituation));
            healthCondition.CopyProperties(_mapper.Map<HealthCondition>(request.HealthCondition));

            if (!await IsValidAsync(sociodemographic))
                return (sociodemographic.ValidationResult, entity);

            if (!await IsValidAsync(healthCondition))
                return (healthCondition.ValidationResult, entity);

            await _sociodemographicSituationRepository.UpdateAsync(sociodemographic, cancellationToken);
            await _healthConditionRepository.UpdateAsync(healthCondition, cancellationToken);
            entity = await _personRepository.UpdateAsync(entity, cancellationToken);
            return (await CommitAsync(cancellationToken), entity);
        }
    }
}
