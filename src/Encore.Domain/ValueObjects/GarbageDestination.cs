namespace Encore.Domain.ValueObjects
{
    public class GarbageDestination : EsusIntegrationBase<GarbageDestination>
    {
        public static GarbageDestination Collected => new GarbageDestination { Code = 93, Description = "Coletado" };
        public static GarbageDestination Burned => new GarbageDestination { Code = 94, Description = "Queimado/Enterrado" };
        public static GarbageDestination ClearSky => new GarbageDestination { Code = 95, Description = "Céu aberto" };       
        public static GarbageDestination Other => new GarbageDestination { Code = 96, Description = "Outro" };
    }
}