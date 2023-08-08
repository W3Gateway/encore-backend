using AutoMapper;
using Encore.Application.Persons.Commands;
using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;

namespace Encore.Application.Persons.Handlers
{
    public class PersonUpdateCommandHandler : CommandHandler, IRequestHandler<PersonUpdateCommand, Response<PersonResponse>?>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMicroregionRepository _microregionRepository;
        private readonly IMapper _mapper;

        public PersonUpdateCommandHandler(IPersonRepository personRepository,
                                          IHomeRepository homeRepository,
                                          IMicroregionRepository microregionRepository,
                                          IMapper mapper) : base(personRepository.UnitOfWork)
        {
            _personRepository = personRepository;
            _homeRepository = homeRepository;
            _microregionRepository = microregionRepository;
            _mapper = mapper;

        }

        public async Task<Response<PersonResponse>?> Handle(PersonUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _personRepository.GetByIdAsync(request.Id);
                if (entity is null)
                {
                    AddError("Não foi encontrado o indivíduo informado na base de dados");
                    return Fail<PersonResponse>(ValidationResult);
                }
                var home = await _homeRepository.GetByIdAsync(request.HomeId);
                if (home is null)
                {
                    AddError("Não foi encontrado o domicílio informado na base de dados");
                    return Fail<PersonResponse>(ValidationResult);
                }

                var microregion = await _microregionRepository.GetByIdAsync(request.MicroregionId);
                if (microregion is null)
                {
                    AddError("Não foi encontrada a microárea informada na base de dados");
                    return Fail<PersonResponse>(ValidationResult);
                }

                if (!await IsValidAsync(entity))
                    return Fail<PersonResponse>(ValidationResult);

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
                entity = await _personRepository.UpdateAsync(entity, cancellationToken);
                var result = await CommitAsync(cancellationToken);
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
    }
}
