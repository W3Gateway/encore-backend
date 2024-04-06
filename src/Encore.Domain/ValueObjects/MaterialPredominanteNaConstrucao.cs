namespace Encore.Domain.ValueObjects
{
    public class MaterialPredominanteNaConstrucao : EsusIntegrationBase<MaterialPredominanteNaConstrucao>
    {
        public static MaterialPredominanteNaConstrucao AlvenariaComRevestimento => new() { Code = 109, Description = "Alvenaria com revestimento" };
        public static MaterialPredominanteNaConstrucao AlvenariaSemRevestimento => new() { Code = 110, Description = "Alvenaria sem revestimento" };
        public static MaterialPredominanteNaConstrucao TaipaComRevestimento => new() { Code = 111, Description = "Taipa com revestimento" };
        public static MaterialPredominanteNaConstrucao TaipaSemRevestimento => new() { Code = 112, Description = "Taipa sem revestimento" };
        public static MaterialPredominanteNaConstrucao MadeiraEmparelhada => new() { Code = 112, Description = "Madeira emparelhada" };
        public static MaterialPredominanteNaConstrucao MaterialAproveitado => new() { Code = 112, Description = "Material aproveitado" };
        public static MaterialPredominanteNaConstrucao Palha => new() { Code = 112, Description = "Palha" };
        public static MaterialPredominanteNaConstrucao OutroMaterial => new() { Code = 112, Description = "Outro material" };
    }
}