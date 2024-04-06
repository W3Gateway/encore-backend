namespace Encore.Domain.ValueObjects.Person
{
    public class Gender : EsusIntegrationBase<Gender>
    {
        public static Gender Male => new Gender { Code = 0, Description = "Masculino"};
        public static Gender Female => new Gender { Code = 1, Description = "Feminino"};
        public static Gender Unknown => new Gender { Code = 4, Description = "Ignorado"};
    }
}
