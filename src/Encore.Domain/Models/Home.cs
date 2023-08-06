using Encore.Domain.Core.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Encore.Domain.Models
{
    public class Home : Entity<Home>
    {
        public string TypeProperty { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; private set; }
        public decimal HouseholdIncome { get; private set; }
        public int NumberMembers { get; private set; }
        public string LocationType { get; set; }
        public string Situation { get; set; }
        public string TypeAccess { get; set; }
        public string TypeDomicile { get; set; }
        public string PredominantMaterial { get; set; }
        public int NumberRooms { get; set; }
        public string WaterSupply { get; set; }
        public string WaterConsumption { get; set; }
        public string SanitaryDrainage { get; set; }
        public string GarbageDestination { get; set; }
        public bool Electricity { get; set; }
        public string Animals { get; set; }
        public string AmountAnimals { get; set; }
        public Guid MicroregionId { get; private set; }
        public Guid AddressId { get; set; }

        #region Mapping
        public Microregion Microregion { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        #endregion

        public Home() { }
        public Home(Guid microregionId, Guid addressId, string contactNumber, string? medicalRecordNumber, decimal householdIncome, int numberMembers)
        {
            TypeProperty = "Casa";
            MicroregionId = microregionId;
            AddressId = addressId;
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
