namespace Encore.Domain.ValueObjects
{
    public class CondicaoDePosseEUsoDaTerra : EsusIntegrationBase<CondicaoDePosseEUsoDaTerra>
    {
        public static CondicaoDePosseEUsoDaTerra Owner => new() { Code = 101, Description = "Proprietário" };
        public static CondicaoDePosseEUsoDaTerra Partner => new() { Code = 102, Description = "Parceiro(a)/Meeiro(a)" };
        public static CondicaoDePosseEUsoDaTerra Settler => new() { Code = 103, Description = "Assentado(a)" };
        public static CondicaoDePosseEUsoDaTerra Squatter => new() { Code = 104, Description = "Posseiro" };
        public static CondicaoDePosseEUsoDaTerra Tenant => new() { Code = 105, Description = "Arrendatário(a)" };
        public static CondicaoDePosseEUsoDaTerra Borrower => new() { Code = 106, Description = "Comodatário(a)" };
        public static CondicaoDePosseEUsoDaTerra Beneficiary => new() { Code = 107, Description = "Beneficiário(a) do banco da terra" };
        public static CondicaoDePosseEUsoDaTerra NotApply => new() { Code = 108, Description = "Não se aplica" };
    }
}