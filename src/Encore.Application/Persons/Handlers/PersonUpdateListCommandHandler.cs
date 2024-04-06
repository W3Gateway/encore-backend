using AutoMapper;
using Encore.Application.Persons.Commands;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Persons.Handlers
{
    public class PersonUpdateCommandHandler : CommandHandler, IRequestHandler<PersonUpdateListCommnad, ValidationResult>
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

        public async Task<ValidationResult> Handle(PersonUpdateListCommnad request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in request.Persons)
                {
                    var result = await UpdatePerson(item, cancellationToken);
                    if (!result.IsValid)
                        return await RollbackAsync(cancellationToken);
                }
                
                return ValidationResult;
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de Indivíduo: " + ex.Message);
                return ValidationResult;
            }
        }

        private async Task<ValidationResult> UpdatePerson(PersonUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _personRepository.GetByIdAsync(request.Id);
            if (entity is null)
            {
                AddError("Não foi encontrado o indivíduo informado na base de dados");
                return ValidationResult;
            }
            var home = await _homeRepository.GetByIdAsync(request.HomeId);
            if (home is null)
            {
                AddError("Não foi encontrado o domicílio informado na base de dados");
                return ValidationResult;
            }

            var microregion = await _microregionRepository.GetByIdAsync(request.MicroregionId);
            if (microregion is null)
            {
                AddError("Não foi encontrada a microárea informada na base de dados");
                return ValidationResult;
            }

            if (!await IsValidAsync(entity))
                return ValidationResult;

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

            var sociodemographic = await _sociodemographicSituationRepository.Include().FirstOrDefaultAsync(s => s.Id == request.SociodemographicSituation.Id);
            var healthCondition = await _healthConditionRepository.Include().FirstOrDefaultAsync(s => s.Id == request.HealthCondition.Id);
            sociodemographic.CopyProperties(_mapper.Map<SociodemographicSituation>(request.SociodemographicSituation));
            healthCondition.CopyProperties(_mapper.Map<HealthCondition>(request.HealthCondition));

            if (!await IsValidAsync(sociodemographic))
                return sociodemographic.ValidationResult;

            if (!await IsValidAsync(healthCondition))
                return healthCondition.ValidationResult;

            await _sociodemographicSituationRepository.UpdateAsync(sociodemographic, cancellationToken);
            await _healthConditionRepository.UpdateAsync(healthCondition, cancellationToken);
            entity = await _personRepository.UpdateAsync(entity, cancellationToken);
            return await CommitAsync(cancellationToken);
        }
    }
}
