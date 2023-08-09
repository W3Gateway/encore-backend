using Encore.Domain.Core.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Encore.Domain.Models
{
    public class Home : Entity<Home>
    {
        public string TypeProperty { get; private set; }
        public string ContactNumber { get; private set; }
        public string? MedicalRecordNumber { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; private set; }
        public string LocationType { get; private set; }
        public string? RuralProductionArea { get; set; }
        public string Situation { get; private set; }
        public string TypeAccess { get; private set; }
        public string TypeDomicile { get; private set; }
        public string PredominantMaterial { get; private set; }
        public int NumberRooms { get; private set; }
        public string WaterSupply { get; private set; }
        public string WaterConsumption { get; private set; }
        public string SanitaryDrainage { get; private set; }
        public string GarbageDestination { get; private set; }
        public bool Electricity { get; private set; }
        public string Animals { get; private set; }
        public int AmountAnimals { get; private set; }
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

        public void Update(Home request)
        {
            MicroregionId = request.MicroregionId;
            ContactNumber = request.ContactNumber;
            MedicalRecordNumber = request.MedicalRecordNumber;
            HouseholdIncome = request.HouseholdIncome;
            NumberMembers = request.NumberMembers;
        }

        public void AddAddress(Guid addressId) => AddressId = addressId;

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
