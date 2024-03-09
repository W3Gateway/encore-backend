using Encore.Domain.Core.Models;
using FluentValidation;

namespace Encore.Domain.Models
{
    public class Address : Entity<Address>
    {
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string StreetType { get; set; }
        public string? StreetComplement { get; set; }
        public string? Landmark { get; set; }
        public int Number { get; set; }

        #region Mapping
        public IEnumerable<Home> Homes { get; set; }
        public IEnumerable<HealthCenter> HealthCenters { get; set; }
        #endregion

        public override async Task<bool> IsValidAsync()
        {
            RuleFor(c => c.PostalCode).NotEmpty().WithMessage("O CEP do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.State).NotEmpty().WithMessage("O estado do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.City).NotEmpty().WithMessage("A cidade do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Neighborhood).NotEmpty().WithMessage("O bairro do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Number).NotEmpty().WithMessage("O numero do endereço é de preenchimento obrigatório.");
            RuleFor(c => c.Street).NotEmpty().WithMessage("O nome da rua do endereço é de preenchimento obrigatório.");

            ValidationResult = await ValidateAsync(this);
            return ValidationResult.IsValid;
        }

        public void Update(Address address)
        {
            PostalCode = address.PostalCode;
            State = address.State;
            City = address.City;
            Neighborhood = address.Neighborhood;
            Street = address.Street;
            StreetType = address.StreetType;
            StreetComplement = address.StreetComplement;
            Landmark = address.Landmark;
            Number = address.Number;
        }
    }

}
