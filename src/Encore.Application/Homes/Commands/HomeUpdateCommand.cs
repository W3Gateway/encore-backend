using Encore.Application.Addresses;
using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Homes.Commands
{
    public class HomeUpdateCommand : Command<Response<HomeResponse>>
    {
        public Guid Id { get; set; }
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
        public AddressCommand Address { get; set; }

        public bool ExecuteTransaction { get; set; } = true;
    }
}
