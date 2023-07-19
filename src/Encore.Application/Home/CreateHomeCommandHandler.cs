using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Home
{
    public class CreateHomeCommandHandler : CommandHandler, IRequestHandler<CreateHomeCommand, Response<CreateHomeResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHomeRepository _homeRepository;

        public CreateHomeCommandHandler(IPersonRepository personRepository, IHomeRepository homeRepository)
        {
            _personRepository = personRepository;
            _homeRepository = homeRepository;
        }

        public async Task<Response<CreateHomeResponse>> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personRepository.Include().Where(c => c.Document == request.ResponsibleDocument).FirstOrDefaultAsync();
                if (person is null)
                {
                    AddError("Não foi encontrada o responsável informado na base de dados" );
                    return Fail<CreateHomeResponse>(ValidationResult);
                }

                var home = new Domain.Models.Home(request.MicroregionId, request.Adderess, request.ContactNumber, request.MedicalRecordNumber, person.Id, request.HouseholdIncome, request.NumberMembers);

                var entity = await _homeRepository.CreateAsync(home);

                return new CreateHomeResponse(entity.TypeProperty, entity.Adderess, entity.ContactNumber, entity.MedicalRecordNumber, entity.HouseholdIncome, entity.NumberMembers, entity.Person, entity.Microregion);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar autenticação: " + ex.Message);
                return Fail<CreateHomeResponse>(ValidationResult);
            }
        }
    }
}
