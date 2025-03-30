namespace Encore.Domain.ValueObjects
{
    public class CondicaoDePosseEUsoDaTerra : EsusIntegrationBase<CondicaoDePosseEUsoDaTerra>
    {
        public static CondicaoDePosseEUsoDaTerra Proprietario => new() { Code = 101, Description = "Proprietário" };
        public static CondicaoDePosseEUsoDaTerra Parceiro => new() { Code = 102, Description = "Parceiro(a)/Meeiro(a)" };
        public static CondicaoDePosseEUsoDaTerra Assentado => new() { Code = 103, Description = "Assentado(a)" };
        public static CondicaoDePosseEUsoDaTerra Posseiro => new() { Code = 104, Description = "Posseiro" };
        public static CondicaoDePosseEUsoDaTerra Arrendatario => new() { Code = 105, Description = "Arrendatário(a)" };
        public static CondicaoDePosseEUsoDaTerra Comodatario => new() { Code = 106, Description = "Comodatário(a)" };
        public static CondicaoDePosseEUsoDaTerra Beneficiario => new() { Code = 107, Description = "Beneficiário(a) do banco da terra" };
        public static CondicaoDePosseEUsoDaTerra TerraIndigenaDemarcada => new() { Code = 208, Description = "Terra indígena demarcada" };
        public static CondicaoDePosseEUsoDaTerra TerraNaoDemarcada => new() { Code = 209, Description = "Terra não demarcada" };
        public static CondicaoDePosseEUsoDaTerra NaoAplica => new() { Code = 108, Description = "Não se aplica" };
    }
}