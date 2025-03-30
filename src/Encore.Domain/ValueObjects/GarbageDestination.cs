namespace Encore.Domain.ValueObjects
{
    public class GarbageDestination : EsusIntegrationBase<GarbageDestination>
    {
        public static GarbageDestination Coletado => new GarbageDestination { Code = 93, Description = "Coletado" };
        public static GarbageDestination Queimado => new GarbageDestination { Code = 221, Description = "Queimado" };
        public static GarbageDestination Enterrado => new GarbageDestination { Code = 222, Description = "Enterrado" };
        public static GarbageDestination CeuAberto => new GarbageDestination { Code = 95, Description = "Céu aberto" };       
        public static GarbageDestination SemTratamento => new GarbageDestination { Code = 96, Description = "Sem Tratamento" };
    }
}