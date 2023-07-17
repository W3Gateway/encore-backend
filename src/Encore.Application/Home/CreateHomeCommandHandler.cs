using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Home
{
    public class CreateHomeCommandHandler : CommandHandler, IRequestHandler<CreateHomeCommand, Response<CreateHomeResponse>?>
    {
        private readonly IPersonRepository _personRepository;

        public CreateHomeCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Response<CreateHomeResponse>?> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personRepository.Include().Where(c => c.Document == request.ResponsibleDocument).FirstOrDefaultAsync();
                if (person is null)
                {
                    AddError("Não foi encontrada o responsável informado na base de dados" );
                    return Fail<CreateHomeResponse>(ValidationResult);
                }

                var home = new Domain.Models.Home(request.MicroregionId, request.Adderess, request.ContactNumber, request.FamilyRecord, person.Id, request.HouseholdIncome, request.NumberMembers);

                return new CreateHomeResponse(home.TypeProperty, home.Adderess, home.ContactNumber, home.FamilyRecord, home.HouseholdIncome, home.NumberMembers, home.Person, home.Microregion);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar autenticação: " + ex.Message);
                return Fail<CreateHomeResponse>(ValidationResult);
            }
        }
    }
}
