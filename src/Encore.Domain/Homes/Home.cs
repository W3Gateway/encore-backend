using Encore.Domain.Core.Models;
using Encore.Domain.Models;
using Encore.Domain.ValueObjects;
using FluentValidation;
using FluentValidation.Results;

namespace Encore.Domain.Homes
{
    public class Home : Entity<Home>
    {
        public string TypeProperty { get; private set; }
        public Address Address { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }
        public Guid MicroregionId { get; private set; }

        #region Mapping
        public IEnumerable<Person> Persons { get; set; }
        public Microregion Microregion { get; set; }
        public List<Visit> Visits { get; set; }
        #endregion

        public Home() {}
        public Home(Guid microregionId, Address address, string contactNumber, string? medicalRecordNumber, decimal householdIncome, int numberMembers) 
        {
            TypeProperty = "Casa";
            MicroregionId = microregionId;
            Address = address;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }

        public void CopyProperties(Guid microregionId, Address address, string contactNumber, string? medicalRecordNumber, decimal householdIncome, int numberMembers)
        {
            MicroregionId = microregionId;
            Address = address;
            ContactNumber = contactNumber;
            MedicalRecordNumber = medicalRecordNumber;
            HouseholdIncome = householdIncome;
            NumberMembers = numberMembers;
        }

        public override async Task<bool> IsValidAsync()
        {
            RuleFor(c => c.TypeProperty).NotEmpty();
            RuleFor(c => c.MicroregionId).NotEmpty().WithMessage("A microarea é de preenchimento obrigatório");
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

        public ValidationResult ValidateRules(Home request)
        {
            var validate = new ValidationResult();
            if (MicroregionId != request.MicroregionId)
                validate.Errors.Add(new ValidationFailure("Domicílio", "Não é possível alterar a microárea de um domicílio"));

            return validate;
        }

    }


}
