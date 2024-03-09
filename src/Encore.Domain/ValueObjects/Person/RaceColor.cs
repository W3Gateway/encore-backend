namespace Encore.Domain.ValueObjects.Person
{
    public class RaceColor : EsusIntegrationBase<RaceColor> 
    {
        public static RaceColor White => new RaceColor { Code = 1, Description = "Branca"};
        public static RaceColor Black => new RaceColor { Code = 2, Description = "Preta"};
        public static RaceColor Brown => new RaceColor { Code = 4, Description = "Parda"};
        public static RaceColor Yellow => new RaceColor { Code = 3, Description = "Amarela"};
        public static RaceColor Indigenous => new RaceColor { Code = 5, Description = "Indígena"};
        public static RaceColor NoInformation => new RaceColor { Code = 6, Description = "Sem informação"};
    }
}
