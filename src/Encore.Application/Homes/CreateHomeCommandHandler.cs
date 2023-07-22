using Encore.Domain.Core.Data;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Homes
{
    public class CreateHomeCommandHandler : CommandHandler, IRequestHandler<CreateHomeCommand, Response<CreateHomeResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHomeRepository _homeRepository;

        public CreateHomeCommandHandler(IPersonRepository personRepository, 
                                        IHomeRepository homeRepository, 
                                        IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _personRepository = personRepository;
            _homeRepository = homeRepository;
        }

        public async Task<Response<CreateHomeResponse>> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _personRepository.Include().Where(c => c.Document == request.ResponsiblePersonDocument).FirstOrDefaultAsync();
                if (person is null)
                {
                    AddError("Não foi encontrada o responsável informado na base de dados" );
                    return Fail<CreateHomeResponse>(ValidationResult);
                }
                
                var home = new Home(request.MicroregionId, request.Adderess, request.ContactNumber, request.MedicalRecordNumber, person.Id, request.HouseholdIncome, request.NumberMembers);
                if (!await IsValidAsync(home))
                    return Fail<CreateHomeResponse>(ValidationResult);
                
                var entity = await _homeRepository.CreateAsync(home, cancellationToken);
                await SaveAsync(cancellationToken);
                return new CreateHomeResponse(entity.TypeProperty,/* entity.Address,*/ entity.ContactNumber, entity.MedicalRecordNumber, entity.HouseholdIncome, entity.NumberMembers, entity.Person, entity.Microregion);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de domicílio: " + ex.Message);
                return Fail<CreateHomeResponse>(ValidationResult);
            }
        }
    }
}
