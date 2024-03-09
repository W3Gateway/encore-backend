namespace Encore.Domain.ValueObjects
{
    public class LandOwnershipAndUseCondition : EsusIntegrationBase<LandOwnershipAndUseCondition>
    {
        public static LandOwnershipAndUseCondition Owner => new LandOwnershipAndUseCondition { Code = 101, Description = "Proprietário" };
        public static LandOwnershipAndUseCondition Partner => new LandOwnershipAndUseCondition { Code = 102, Description = "Parceiro(a)/Meeiro(a)" };
        public static LandOwnershipAndUseCondition Settler => new LandOwnershipAndUseCondition { Code = 103, Description = "Assentado(a)" };
        public static LandOwnershipAndUseCondition Landholder => new LandOwnershipAndUseCondition { Code = 104, Description = "Posseiro" };
        public static LandOwnershipAndUseCondition Lessor => new LandOwnershipAndUseCondition { Code = 105, Description = "Arrendatário(a)" };
        public static LandOwnershipAndUseCondition Loaner => new LandOwnershipAndUseCondition { Code = 106, Description = "Comodatário(a)" };
        public static LandOwnershipAndUseCondition LandBankBeneficiary => new LandOwnershipAndUseCondition { Code = 107, Description = "Beneficiário(a) do banco da terra" };
        public static LandOwnershipAndUseCondition NotApplicable => new LandOwnershipAndUseCondition { Code = 108, Description = "Não se aplica" };
    }


}
