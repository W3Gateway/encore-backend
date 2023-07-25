using AutoMapper;
using Encore.Application.Persons.Commands;
using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Data;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Persons.Handlers
{
    public class PersonCreateCommandHandler : CommandHandler, IRequestHandler<PersonCreateCommand, Response<PersonResponse>?>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMicroregionRepository _microregionRepository;
        private readonly IMapper _mapper;

        public PersonCreateCommandHandler(IPersonRepository personRepository,
                                        IHomeRepository homeRepository,
                                        IMicroregionRepository microregionRepository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _personRepository = personRepository;
            _homeRepository = homeRepository;
            _microregionRepository = microregionRepository;
            _mapper = mapper;

        }

        public async Task<Response<PersonResponse>?> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var home = await _homeRepository.Include().FirstOrDefaultAsync(c => c.Id == request.HomeId);
                if (home is null)
                {
                    AddError("Não foi encontrada o domicílio informado na base de dados");
                    return Fail<PersonResponse>(ValidationResult);
                }

                var microregion = await _microregionRepository.Include().FirstOrDefaultAsync(c => c.Id == request.MicroregionId);
                if (microregion is null)
                {
                    AddError("Não foi encontrada a microárea informada na base de dados");
                    return Fail<PersonResponse>(ValidationResult);
                }
                var person = new Person(request.Name,
                                        request.SocialName,
                                        request.BirthDate,
                                        request.Nationality,
                                        request.Sex,
                                        request.SkinColor,
                                        request.Document,
                                        request.Email,
                                        request.ContactNumber,
                                        request.SocialIdentification,
                                        request.DocumentType,
                                        request.FatherName,
                                        request.MotherName,
                                        request.IsHeadFamily,
                                        microregion.Id,
                                        home.Id);

                if (!await IsValidAsync(person))
                    return Fail<PersonResponse>(ValidationResult);

                var entity = await _personRepository.CreateAsync(person, cancellationToken);
                await SaveAsync(cancellationToken);
                return _mapper.Map<PersonResponse>(entity);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de Indivíduo: " + ex.Message);
                return Fail<PersonResponse>(ValidationResult);
            }
        }
    }
}
