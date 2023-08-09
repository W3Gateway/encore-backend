using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Homes.Commands
{
    public class HomeCreateCommand : Command<Response<HomeResponse>>
    {
        public string TypeProperty { get; set; }
        public string LocationType { get; set; }
        public string? RuralProductionArea { get; set; }
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
        public int AmountAnimals { get; set; }
        public string ContactNumber { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string StreetType { get; set; }
        public string? StreetComplement { get; set; }
        public string? Landmark { get; set; }
        public int Number { get; set; }
        public Guid MicroregionId { get; set; }

        public bool ExecuteTransaction { get; set; } = true;

    }
}
