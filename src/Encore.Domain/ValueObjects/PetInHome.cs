namespace Encore.Domain.ValueObjects
{
    public class PetInHome : EsusIntegrationBase<PetInHome>
    {
        public static PetInHome Cat => new PetInHome { Code = 128, Description = "Gato" };
        public static PetInHome Dog => new PetInHome { Code = 129, Description = "Cachorro" };
        public static PetInHome Bird => new PetInHome { Code = 130, Description = "Pássaro" };
        public static PetInHome Other => new PetInHome { Code = 132, Description = "Outros" };
    }
}
