using Encore.Domain.Core.Models;
using Encore.Domain.ValueObjects;
using FluentValidation;

namespace Encore.Domain.Models
{
    public class Home : Entity<Home>
    {
        public string TypeProperty { get; private set; }
        public Address Address { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }
        public Guid ResponsiblePersonId { get; private set; }
        public Guid MicroregionId { get; private set; }

        #region Mapping
        public Person Person { get; set; }
        public Microregion Microregion { get; set; }
        #endregion

        public Home(Guid microregionId, Address address, string contactNumber, string? medicalRecordNumber, Guid responsiblePersonId, decimal householdIncome, int numberMembers) 
        {
            TypeProperty = "House";
            MicroregionId = microregionId;
            Address = address;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            ResponsiblePersonId = responsiblePersonId;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }

        public override async Task<bool> IsValidAsync()
        {
            RuleFor(c => c.TypeProperty).NotEmpty();
            RuleFor(c => c.MicroregionId).NotEmpty().WithMessage("A microarea é de preenchimento obrigatório");
            RuleFor(c => c.ResponsiblePersonId).NotEmpty().WithMessage("É obrigatório informar o responsável familiar");
            RuleFor(c => c.HouseholdIncome).NotEmpty().GreaterThan(0).WithName("Renda Familiar").WithMessage("{PropertyName} deve ser maior que 0.");
            RuleFor(c => c.NumberMembers).NotEmpty().GreaterThan(0).WithName("Número de membros").WithMessage("O {PropertyName} deve ser maior que 0.");
            RuleFor(c => c.Address.PostalCode).NotEmpty().WithMessage("O CEP do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Address.State).NotEmpty().WithMessage("O estado do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Address.City).NotEmpty().WithMessage("A cidade do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Address.Neighborhood).NotEmpty().WithMessage("O bairro do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Address.Number).NotEmpty().WithMessage("O numero do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Address.Street).NotEmpty().WithMessage("O nome da rua do endereço é de preenchimento obrigatório.");

            ValidationResult = await ValidateAsync(this);
            return ValidationResult.IsValid;
        }
    }


}
