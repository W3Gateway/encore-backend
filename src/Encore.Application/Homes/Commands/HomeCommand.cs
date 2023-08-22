using Encore.Application.Addresses;

namespace Encore.Application.Homes.Commands
{
    public class HomeCommand
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
        public string HomeContact { get; set; }
        public string? MedicalRecordNumber { get; set; }
        public decimal HouseholdIncome { get; set; }
        public int NumberMembers { get; set; }
        public AddressCommand Address { get; set; }
    }
}
